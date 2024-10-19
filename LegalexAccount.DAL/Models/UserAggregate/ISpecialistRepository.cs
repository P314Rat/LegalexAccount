namespace LegalexAccount.DAL.Models.UserAggregate
{
    public interface ISpecialistRepository
    {
        Task CreateAsync(Specialist item);
        Task<Specialist> GetByEmailAsync(string email);
        Task<IEnumerable<Specialist>> GetAllAsync();
        Task DeleteByIdAsync(string email);
        Task UpdateAsync(Specialist item);
    }
}
