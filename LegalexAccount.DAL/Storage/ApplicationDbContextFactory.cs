using LegalexAccount.DAL.Models;
using Microsoft.EntityFrameworkCore;


namespace LegalexAccount.DAL.Storage
{
    public class ApplicationDbContextFactory : IApplicationDbContextFactory
    {
        private readonly DbContextOptions<ApplicationDbContext> _options;
        private List<ApplicationDbContext> _dbContexts = new();


        public ApplicationDbContextFactory(DbContextOptions<ApplicationDbContext> options)
        {
            _options = options;
        }

        public ApplicationDbContext CreateDbContext()
        {
            ApplicationDbContext dbContext = new(_options);
            //_dbContexts.Add(dbContext);

            return dbContext;
        }

        //public void Dispose()
        //{
        //    foreach (var dbContext in _dbContexts)
        //    {
        //        dbContext.Dispose();
        //    }

        //    GC.SuppressFinalize(this);
        //}
    }
}
