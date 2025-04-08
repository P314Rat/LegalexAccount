using Domain.Core.UserAggregate;
using System.Linq.Expressions;


namespace Infrastructure.Specifications.UserAggregate
{
    public class UserByEmailSpecification : Specification<User>
    {
        private readonly string _email;


        public UserByEmailSpecification(string email)
        {
            _email = email;
        }

        public override Expression<Func<User, bool>> Criteria =>
            x => x.Email == _email;
    }
}
