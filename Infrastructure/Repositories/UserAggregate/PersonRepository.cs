using Domain.Core.UserAggregate;
using Infrastructure.Repositories.Contracts;


namespace Infrastructure.Repositories.UserAggregate
{
    public class PersonRepository : IUserRepository<Person, Guid>
    {
        private readonly ApplicationDbContext _dbContext;


        public PersonRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Task CreateAsync(Person item)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<Person?> GetAsync(string email)
        {
            throw new NotImplementedException();
        }

        public Task<Person?> GetAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Person item)
        {
            throw new NotImplementedException();
        }
    }
}
