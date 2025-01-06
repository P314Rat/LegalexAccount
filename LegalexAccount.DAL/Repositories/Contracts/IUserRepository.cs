using LegalexAccount.DAL.Models.UserAggregate;


namespace LegalexAccount.DAL.Repositories.Contracts
{
    public interface IUserRepository
    {
        Task<User> GetByEmailAsync(string email);
        Task<User> GetByNameAsync(string name);
        Task<bool> IsExistsAsync(string email);
    }
}
