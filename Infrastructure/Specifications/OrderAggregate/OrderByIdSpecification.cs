using Domain.Core.OrderAggregate;
using System.Linq.Expressions;


namespace Infrastructure.Specifications.OrderAggregate
{
    public class OrderByIdSpecification : Specification<Order>
    {
        private readonly int _id;


        public OrderByIdSpecification(int id)
        {
            _id = id;
        }

        public override Expression<Func<Order, bool>> Criteria => x => x.Id == _id;
    }
}
