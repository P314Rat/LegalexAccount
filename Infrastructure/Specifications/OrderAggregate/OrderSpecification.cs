using Domain.Core.OrderAggregate;
using System.Linq.Expressions;


namespace Infrastructure.Specifications.OrderAggregate
{
    public class OrderSpecification : Specification<Order>
    {
        private readonly int _skip;
        private readonly int _take;


        public OrderSpecification(int skip, int take)
        {
            _skip = skip;
            _take = take;
        }

        public override Expression<Func<Order, bool>> Criteria => x => true;
        public override int? Skip => _skip;
        public override int? Take => _take;
    }
}
