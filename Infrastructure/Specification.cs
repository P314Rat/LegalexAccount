using Infrastructure.Contracts;
using System.Linq.Expressions;


namespace Infrastructure
{
    public abstract class Specification<T> : ISpecification<T>
    {
        public abstract Expression<Func<T, bool>> Criteria {  get; }
        public virtual Func<IQueryable<T>, IOrderedQueryable<T>>? OrderBy => null;
        public virtual Func<IQueryable<T>, IQueryable<T>>? Include => null;
        public virtual int? Skip => null;
        public virtual int? Take => null;
    }
}
