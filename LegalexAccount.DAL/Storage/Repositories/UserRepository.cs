using LegalexAccount.DAL.Models.UserAggregate;


namespace LegalexAccount.DAL.Storage.Repositories
{
    public class UserRepository : IUserRepository<User>
    {
        private readonly ApplicationDbContext _dbContext;


        public UserRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public User GetById(string id)
        {
            throw new NotImplementedException();
        }

        public User GetByEmail(string email)
        {
            var client = _dbContext.Clients.FirstOrDefault(c => c.Email == email);

            if (client == null)
            {
                var specialist = _dbContext.Specialists.FirstOrDefault(s => s.Email == email);
                
                if (specialist == null)
                    throw new InvalidOperationException("User was not found");

                return specialist;
            }

            return client;
        }

        public IEnumerable<User> GetAll()
        {
            throw new NotImplementedException();
        }

        public bool IsExists(string email)
        {
            var isLoginExists = _dbContext.Clients
                .Select(x => x.Email)
                .Union(_dbContext.Specialists.Select(x => x.Email))
                .Any(x => x == email);

            return isLoginExists;
        }
    }
}
