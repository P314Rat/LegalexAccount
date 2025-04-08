using Domain.Core.CaseAggregate;
using System.Linq.Expressions;


namespace Infrastructure.Specifications.CaseAggregate
{
    public class CasesByCustomerEmailSpecification : Specification<Case>
    {
        private readonly string _customerEmail;


        public CasesByCustomerEmailSpecification(string customerEmail)
        {
            _customerEmail = customerEmail;
        }

        public override Expression<Func<Case, bool>> Criteria => 
            x => x.Customer.Email == _customerEmail;
    }
}
