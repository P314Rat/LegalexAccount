using Domain.Core.UserAggregate;
using Microsoft.EntityFrameworkCore;
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
        public override Func<IQueryable<User>, IQueryable<User>>? Include =>
            x => x
            .Include(u => u.Role)
            .Include(u => (u as Client).ClientRole)
            .Include(u => (u as Specialist).SpecialistRole);
    }
}
