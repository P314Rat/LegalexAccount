using Domain.Core.CaseAggregate;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;


namespace Infrastructure.Specifications.CaseAggregate
{
    public class CaseSpecification : Specification<Case>
    {
        private readonly int _skip;
        private readonly int _take;
        private readonly Expression<Func<Case, bool>> _criteria;


        public  CaseSpecification(string? email, int skip, int take)
        {
            _skip = skip;
            _take = take;
            _criteria = email != null
                ? x => x.Customer.Email == email
                : x => true;
        }

        public override int? Skip => _skip;
        public override int? Take => _take;
        public override Expression<Func<Case, bool>> Criteria => _criteria;
        public override Func<IQueryable<Case>, IQueryable<Case>>? Include =>
            x => x
            .Include(x => x.Customer)
            .Include(x => x.Assignees);
    }
}
