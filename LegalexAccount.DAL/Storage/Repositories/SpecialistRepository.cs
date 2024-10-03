using LegalexAccount.DAL.Models.UserAggregate;
using Microsoft.EntityFrameworkCore;


namespace LegalexAccount.DAL.Storage.Repositories
{
    public class SpecialistRepository : ISpecialistRepository
    {
        private readonly ApplicationDbContext _dbContext;


        public SpecialistRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Create(Specialist item)
        {
            var entry = _dbContext?.Specialists?.Add(item);

            if (entry == null || entry.State != EntityState.Added)
                throw new InvalidOperationException("Specialist was not created");
        }

        public Specialist GetById(string id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Specialist> GetAll()
        {
            var items = _dbContext?.Specialists.ToList();

            if (items == null)
                throw new InvalidOperationException("Specialists was not found");

            return items;
        }

        public void Delete(Specialist item)
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

        public void Update(Specialist item)
        {
            throw new NotImplementedException();
        }
    }
}
