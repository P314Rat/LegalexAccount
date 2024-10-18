namespace LegalexAccount.DAL.Models.UserAggregate
{
    public interface IPersonRepository
    {
        Task CreateAsync(Person item);
        Task<Person> GetByEmailAsync(string email);
        Task<IEnumerable<Person>> GetAllAsync();
        Task DeleteByEmailAsync(string email);
        Task UpdateAsync(Person item);
    }
}
