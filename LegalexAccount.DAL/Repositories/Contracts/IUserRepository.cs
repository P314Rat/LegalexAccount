using LegalexAccount.DAL.Models.UserAggregate;


namespace LegalexAccount.DAL.Repositories.Contracts
{
    public interface IUserRepository<T> where T : User
    {
        Task<T?> GetByEmailAsync(string email);
        Task<bool> IsExistsAsync(string email);
    }
}
