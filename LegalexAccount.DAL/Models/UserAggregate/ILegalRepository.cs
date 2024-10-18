namespace LegalexAccount.DAL.Models.UserAggregate
{
    public interface ILegalRepository
    {
        Task CreateAsync(Legal item);
        Task<Legal> GetByEmailAsync(string email);
        Task<IEnumerable<Legal>> GetAllAsync();
        Task DeleteByEmailAsync(string email);
        Task UpdateAsync(Legal item);
    }
}
