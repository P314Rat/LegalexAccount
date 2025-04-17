using Domain.Core.UserAggregate;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;


namespace Infrastructure.Specifications.ClientAggregate
{
    public class ClientSpecification : Specification<Client>
    {
        private readonly int _skip;
        private readonly int _take;


        public ClientSpecification(int skip, int take)
        {
            _skip = skip;
            _take = take;
        }

        public override int? Skip => _skip;
        public override int? Take => _take;
        public override Expression<Func<Client, bool>> Criteria => x => true;
        public override Func<IQueryable<Client>, IQueryable<Client>>? Include =>
            x => x
            .Include(u => u.Role)
            .Include(c => c.ClientRole);
    }
}
