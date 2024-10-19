using LegalexAccount.DAL.Models;
using Microsoft.EntityFrameworkCore;


namespace LegalexAccount.DAL.Storage
{
    public class ApplicationDbContextFactory : IApplicationDbContextFactory
    {
        private readonly DbContextOptions<ApplicationDbContext> _options;
        private Dictionary<string, List<ApplicationDbContext>> _dbContextList;


        public ApplicationDbContextFactory(DbContextOptions<ApplicationDbContext> options)
        {
            _options = options;
            _dbContextList = new();
        }

        public ApplicationDbContext CreateDbContext(string repositoryName)
        {
            ApplicationDbContext newDbContext = new(_options);

            if (_dbContextList.Keys.Contains(repositoryName))
            {
                var repositoryDbContextList = _dbContextList.GetValueOrDefault(repositoryName);
                repositoryDbContextList?.Add(newDbContext);
            }
            else
                _dbContextList.Add(repositoryName, new List<ApplicationDbContext>() { newDbContext });

            return newDbContext;
        }

        public void Dispose(string repositoryName)
        {
            var list = _dbContextList.GetValueOrDefault(repositoryName);

            list?.ForEach(context =>
            {
                context.Dispose();
                GC.SuppressFinalize(context);
            });

            GC.SuppressFinalize(this);
        }
    }
}
