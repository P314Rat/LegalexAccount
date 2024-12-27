using LegalexAccount.DAL.Models.UserAggregate;
using LegalexAccount.DAL.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;

namespace LegalexAccount.DAL.Repositories
{
    public class ClientRepository : IRepository<Client, Guid>
    {
        private const string REPOSITORY_NAME = "Client";
        private readonly IApplicationDbContextFactory _dbContextFactory;


        public ClientRepository(IApplicationDbContextFactory dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }

        public async Task<Client> GetByEmailAsync(string email)
        {
            var tasks = new Dictionary<Task<Client?>, ApplicationDbContext>();

            for (int i = 0; i < 3; i++)
            {
                var dbContext = _dbContextFactory.CreateDbContext(REPOSITORY_NAME);
                var task = i switch
                {
                    0 => dbContext.Individuals.FirstOrDefaultAsync(c => c.Email == email).ContinueWith(t => (Client?)t.Result),
                    1 => dbContext.LegalEntities.FirstOrDefaultAsync(c => c.Email == email).ContinueWith(t => (Client?)t.Result),
                    _ => Task.FromResult<Client?>(null)
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
                else
                {
                    tasks.Remove(completedTask);
                }
            }

            _dbContextFactory.Dispose(REPOSITORY_NAME);
            throw new InvalidOperationException("Client was not found");
        }

        public async Task<IEnumerable<Client>> GetAllAsync()
        {
            var tasks = new Dictionary<Task<List<Client>>, ApplicationDbContext>();
            var resultList = new List<Client>();

            for (int i = 0; i < 2; i++)
            {
                var dbContext = _dbContextFactory.CreateDbContext(REPOSITORY_NAME);
                Task<List<Client>> task = i switch
                {
                    0 => dbContext.Individuals.Select(x => (Client)x).ToListAsync(),
                    1 => dbContext.LegalEntities.Select(x => (Client)x).ToListAsync(),
                    _ => Task.FromResult(new List<Client>())
                };

                tasks.Add(task, dbContext);
            }

            while (tasks.Any())
            {
                var pendingTasks = tasks.Keys.ToArray();
                var completedTask = await Task.WhenAny(pendingTasks);

                if (await completedTask is List<Client> clients)
                {
                    resultList.AddRange(clients);
                    tasks.Remove(completedTask);
                }
            }

            _dbContextFactory.Dispose(REPOSITORY_NAME);

            return resultList;
        }

        public Task CreateAsync(Client item)
        {
            throw new NotImplementedException();
        }

        public Task<Client> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task DeleteByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Client item)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Client> AsQueryable()
        {
            var dbContext = _dbContextFactory.CreateDbContext(REPOSITORY_NAME);
            var resultQuery = dbContext.Specialists.Cast<Client>()
                .Union(dbContext.Individuals.Cast<Client>());

            return resultQuery;
        }
    }
}
