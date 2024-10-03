using LegalexAccount.DAL.Models.UserAggregate;
using Microsoft.EntityFrameworkCore;


namespace LegalexAccount.DAL.Storage.Repositories
{
    public class ClientRepository : IClientRepository
    {
        private readonly ApplicationDbContext _dbContext;


        public ClientRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Create(Client item)
        {
            var entry = _dbContext?.Clients?.Add(item);

            if (entry == null || entry.State != EntityState.Added)
                throw new InvalidOperationException("Client was not created");
        }
        public Client GetById(string id)
        {
            throw new NotImplementedException();
        }
        public IEnumerable<Client> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Delete(Client item)
        {
            throw new NotImplementedException();
        }

        public void DeleteById(string id)
        {
            throw new NotImplementedException();
        }

        public void DeleteAll()
        {
            throw new NotImplementedException();
        }

        public void Update(Client item)
        {
            throw new NotImplementedException();
        }
    }
}
