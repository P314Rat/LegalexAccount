using AutoMapper;
using Domain.Core.UserAggregate;
using Infrastructure.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;


namespace Infrastructure.Repositories.UserAggregate
{
    public class UserRepository : IUserRepository<User, Guid>
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;


        public UserRepository(ApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public Task CreateAsync(User item)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<User?> GetAsync(string email)
        {
            var result = await _dbContext.Users.FirstOrDefaultAsync(x => x.Email == email);

            return result;
        }

        public Task<User?> GetAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<List<User>> GetAsync()
        {
            throw new NotImplementedException();
        }

        public async Task UpdateAsync(User item)
        {
            var oldUser = await _dbContext.Users.FirstOrDefaultAsync(x => x.Email == item.Email);

            if (oldUser == null)
                throw new Exception("User was not found");

            _mapper.Map(item, oldUser);
            _dbContext.Users.Update(item);
            await _dbContext.SaveChangesAsync();
        }
    }
}
