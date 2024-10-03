using LegalexAccount.DAL.Models.CaseAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;


namespace LegalexAccount.DAL.Storage.Repositories
{
    public class CaseRepository : ICaseRepository
    {
        private readonly ApplicationDbContext _dbContext;


        public CaseRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Create(Case item)
        {
            var entry = _dbContext?.Cases?.Add(item);

            if (entry == null || entry.State != EntityState.Added)
                throw new InvalidOperationException("Case was not created");
        }

        public Case GetById(int id)
        {
            var item = _dbContext?.Cases?.FirstOrDefault(x => x.Id == id);

            if (item == null)
                throw new InvalidOperationException("Case was not found");

            return item;
        }

        public IEnumerable<Case> GetAll()
        {
            var items = _dbContext?.Cases.ToList();

            if (items == null)
                throw new InvalidOperationException("Cases was not found");

            return items;
        }

        public void Delete(Case item)
        {
            var entry = _dbContext?.Cases?.Remove(item);

            if (entry == null || entry.State != EntityState.Deleted)
                throw new InvalidOperationException("Case was not deleted");
        }

        public void DeleteById(int id)
        {
            var item = _dbContext?.Cases?.FirstOrDefault(x => x.Id == id);
            EntityEntry<Case>? entry = null;

            if (item != null)
                entry = _dbContext?.Cases?.Remove(item);

            if (entry == null || entry.State != EntityState.Deleted)
                throw new InvalidOperationException("Case was not deleted");
        }

        public void DeleteAll()
        {
            throw new NotImplementedException();
        }

        public void Update(Case item)
        {
            throw new NotImplementedException();
        }
    }
}
