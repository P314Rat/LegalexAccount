namespace LegalexAccount.DAL.Models.CaseAggregate
{
    public interface ICaseRepository
    {
        Task CreateAsync(Case item);
        Task<Case> GetByIdAsync(int id);
        Task<IEnumerable<Case>> GetAllAsync();
        Task DeleteByIdAsync(int id);
        Task UpdateAsync(Case item);
    }
}
