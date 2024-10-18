namespace LegalexAccount.DAL.Models.UserAggregate
{
    public interface IUserRepository
    {
        Task<User> GetByEmailAsync(string email);
        bool IsExists(string email);
    }
}
