using LegalexAccount.DAL.Models;
using LegalexAccount.DAL.Models.UserAggregate;
using Microsoft.EntityFrameworkCore;


namespace LegalexAccount.DAL.Storage.Repositories
{
    public class ClientRepository : IClientRepository
    {
        private const string REPOSITORY_NAME = "Client";
        private readonly IApplicationDbContextFactory _dbContextFactory;


        public ClientRepository(IApplicationDbContextFactory dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }

        public async Task<Client> GetByEmailAsync(string email)
        {
            var tasks = new Dictionary<Task<Client>, ApplicationDbContext>();

            for (int i = 0; i < 3; i++)
            {
                var dbContext = _dbContextFactory.CreateDbContext(REPOSITORY_NAME);
                Task<Client> task = i switch
                {
                    0 => dbContext.Individuals.FirstOrDefaultAsync(c => c.Email == email).ContinueWith(t => (Client)t.Result),
                    1 => dbContext.LegalEntities.FirstOrDefaultAsync(c => c.Email == email).ContinueWith(t => (Client)t.Result),
                    _ => Task.FromResult<Client>(null)
                };

                tasks.Add(task, dbContext);
            }

            while (tasks.Any())
            {
                var pendingTasks = tasks.Keys.ToArray();
                var completedTask = await Task.WhenAny(pendingTasks);

                if (await completedTask is Client client && client != null)
                {
                    _dbContextFactory.Dispose(REPOSITORY_NAME);

                    return client;
                }

                tasks.GetValueOrDefault(completedTask)?.Dispose();
                tasks.Remove(completedTask);
            }

            throw new InvalidOperationException("Client was not found");
        }

        public async Task<IEnumerable<Client>> GetAllAsync()
        {
            var dbContext = _dbContextFactory.CreateDbContext(REPOSITORY_NAME);

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
            _dbContextFactory.Dispose(REPOSITORY_NAME);

            if (items == null)
                throw new InvalidOperationException("Clients was not found");

            return items.Cast<Client>();
        }
    }
}
