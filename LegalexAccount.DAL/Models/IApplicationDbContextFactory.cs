using LegalexAccount.DAL.Storage;


namespace LegalexAccount.DAL.Models
{
    public interface IApplicationDbContextFactory
    {
        ApplicationDbContext CreateDbContext(string repositoryName);
        void Dispose(string repositoryName);
    }
}
