using Domain.Core.UserAggregate;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;


namespace Infrastructure.Specifications.UserAggregate
{
    public class SpecialistSpecification : Specification<Specialist>
    {
        private readonly int _skip;
        private readonly int _take;


        public SpecialistSpecification(int skip, int take)
        {
            _skip = skip;
            _take = take;
        }

        public override int? Skip => _skip;
        public override int? Take => _take;
        public override Expression<Func<Specialist, bool>> Criteria => x => true;
        public override Func<IQueryable<Specialist>, IQueryable<Specialist>>? Include =>
            x => x
            .Include(u => u.Role)
            .Include(s => s.SpecialistRole);
    }
}
