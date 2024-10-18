using LegalexAccount.DAL.Models;
using LegalexAccount.DAL.Models.UserAggregate;
using Microsoft.EntityFrameworkCore;


namespace LegalexAccount.DAL.Storage.Repositories
{
    public class ClientRepository : IClientRepository
    {
        private readonly IApplicationDbContextFactory _dbContextFactory;


        public ClientRepository(IApplicationDbContextFactory dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }

        public async Task<Client> GetByEmailAsync(string email)
        {
            var tasks = new Dictionary<Task, ApplicationDbContext>();

            for (int i = 0; i < 3; i++)
            {
                var dbContext = _dbContextFactory.CreateDbContext();

                Task task = i switch
                {
                    0 => dbContext.Individuals.FirstOrDefaultAsync(c => c.Email == email),
                    1 => dbContext.LegalEntities.FirstOrDefaultAsync(c => c.Email == email),
                    _ => Task.FromResult<Client>(null)
                };

                tasks.Add(task, dbContext);
            }

            while (tasks.Any())
            {
                var pendingTasks = tasks.Keys.ToArray();
                var completedTask = await Task.WhenAny(pendingTasks);

                switch (completedTask)
                {
                    case Task<Person> person:
                        if (person.Result != null)
                            return person.Result;
                        break;
                    case Task<Legal> legal:
                        if (legal.Result != null)
                            return legal.Result;
                        break;
                }

                tasks.GetValueOrDefault(completedTask)?.Dispose();
                tasks.Remove(completedTask);
            }

            throw new InvalidOperationException("Client was not found");
        }

        public async Task<IEnumerable<Client>> GetAllAsync()
        {
            var dbContext = _dbContextFactory.CreateDbContext();
            var items = await dbContext?
                .Individuals.Select(x => new
                {
                    x.Email,
                    x.FirstName,
                    x.LastName,
                    x.SurName
                }).Union(dbContext.LegalEntities.Select(x => new
                {
                    x.Email,
                    x.FirstName,
                    x.LastName,
                    x.SurName
                })).ToListAsync();

            if (items == null)
                throw new InvalidOperationException("Cases was not found");

            return items.Cast<Client>();
        }
    }
}
