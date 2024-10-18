using LegalexAccount.DAL.Models;
using LegalexAccount.DAL.Models.UserAggregate;

namespace LegalexAccount.DAL.Storage.Repositories
{
    public class PersonRepository : IPersonRepository
    {
        private readonly IApplicationDbContextFactory _dbContextFactory;


        public PersonRepository(IApplicationDbContextFactory dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }

        public Task CreateAsync(Person item)
        {
            throw new NotImplementedException();
        }

        public Task DeleteByEmailAsync(string email)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Person>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Person> GetByEmailAsync(string email)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Person item)
        {
            throw new NotImplementedException();
        }
    }
}
