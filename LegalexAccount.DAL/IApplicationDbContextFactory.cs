namespace LegalexAccount.DAL
{
    public interface IApplicationDbContextFactory
    {
        ApplicationDbContext CreateDbContext(string repositoryName);
        void Dispose(string repositoryName);
    }
}
