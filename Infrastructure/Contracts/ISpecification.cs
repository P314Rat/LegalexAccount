using System.Linq.Expressions;


namespace Infrastructure.Contracts
{
    public interface ISpecification<T>
    {
        Expression<Func<T, bool>> Criteria { get; }
        Func<IQueryable<T>, IOrderedQueryable<T>>? OrderBy { get; }
        Func<IQueryable<T>, IQueryable<T>>? Include { get; }
        int? Skip { get; }
        int? Take { get; }
    }
}
