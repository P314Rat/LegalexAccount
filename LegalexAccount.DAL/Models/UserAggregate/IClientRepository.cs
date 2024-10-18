namespace LegalexAccount.DAL.Models.UserAggregate
{
    public interface IClientRepository
    {
        Task<Client> GetByEmailAsync(string email);
        Task<IEnumerable<Client>> GetAllAsync();
    }
}
