namespace LegalexAccount.DAL.Models.UserAggregate
{
    public interface ISpecialistRepository
    {
        Task CreateAsync(Specialist item);
        Task<Specialist> GetByEmailAsync(string email);
        Task<IEnumerable<Specialist>> GetAllAsync();
        Task DeleteByIdAsync(int id);
        Task UpdateAsync(Specialist item);
    }
}
