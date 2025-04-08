using Domain.Core;
using Infrastructure.Contracts;
using Microsoft.EntityFrameworkCore;


namespace Infrastructure
{
    public class Repository<TEntity, TId> : IRepository<TEntity, TId>
        where TEntity : BaseEntity<TId>
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly DbSet<TEntity> _dbSet;


        public Repository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = _dbContext.Set<TEntity>();
        }

        public async Task CreateAsync(TEntity entity)
        {
            await _dbSet.AddAsync(entity);
        }

        public async Task<IEnumerable<TEntity>> GetAsync(ISpecification<TEntity> specification)
        {
            var query = _dbSet.AsNoTracking().Where(specification.Criteria);

            if (specification.OrderBy != null)
                query = specification.OrderBy(query);

            if (specification.Include != null)
                query = specification.Include(query);

            if (specification.Skip.HasValue)
                query = query.Skip(specification.Skip.Value);

            if (specification.Take.HasValue)
                query = query.Take(specification.Take.Value);

            return await query.ToListAsync();
        }

        public async Task UpdateAsync(TEntity updatedEntity, ISpecification<TEntity> specification)
        {
            var entity = await _dbSet.FirstOrDefaultAsync(specification.Criteria);

            if (entity != null)
            {
                var entry = _dbSet.Entry(entity);
                var propertiesToUpdate = entry.OriginalValues.Properties
                    .Where(property => !Equals(
                        entry.OriginalValues[property],
                        typeof(TEntity).GetProperty(property.Name)
                        ?.GetValue(updatedEntity))
                    );

                foreach (var property in propertiesToUpdate)
                {
                    var updatedValue = typeof(TEntity).GetProperty(property.Name)?.GetValue(updatedEntity);
                    entry.CurrentValues[property] = updatedValue;
                }
            }

            //Пытаюсь сделать вменяемый обобщенный механизм обновления только измененных свойств
        }

        public async Task DeleteAsync(ISpecification<TEntity> specification)
        {
            var entity = await _dbSet.FirstOrDefaultAsync(specification.Criteria);

            if (entity != null)
                _dbSet.Remove(entity);
        }

        public async Task<int> CountAsync()
        {
            return await _dbSet.AsNoTracking().CountAsync();
        }
    }
}
