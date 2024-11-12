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
            var tasks = new Dictionary<Task<IEnumerable<Client>>, ApplicationDbContext>();

            for (int i = 0; i < 3; i++)
            {
                var dbContext = _dbContextFactory.CreateDbContext(REPOSITORY_NAME);
                var task = i switch
                {
                    0 => dbContext.Individuals.Select(x => (Client)x).ToListAsync().ContinueWith(x => (IEnumerable<Client>)x.Result),
                    1 => dbContext.LegalEntities.Select(x => (Client)x).ToListAsync().ContinueWith(x => (IEnumerable<Client>)x.Result),
                    _ => Task.FromResult(Enumerable.Empty<Client>())
                };

                tasks.Add(task, dbContext);
            }

            while (tasks.Any())
            {
                var pendingTasks = tasks.Keys.ToArray();
                var completedTask = await Task.WhenAny(pendingTasks);

                if (await completedTask is IEnumerable<Client> clients && clients.Any())
                {
                    _dbContextFactory.Dispose(REPOSITORY_NAME);

                    return clients;
                }
                else
                {
                    tasks.Remove(completedTask);
                }
            }

            _dbContextFactory.Dispose(REPOSITORY_NAME);
            throw new Exception("Clients was not found");
        }
    }
}
