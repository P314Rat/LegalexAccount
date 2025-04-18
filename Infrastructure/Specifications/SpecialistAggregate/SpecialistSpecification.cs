﻿using Domain.Core.UserAggregate;
using System.Linq.Expressions;

namespace Infrastructure.Specifications.SpecialistAggregate
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

        public override Expression<Func<Specialist, bool>> Criteria => x => true;
        public override int? Skip => _skip;
        public override int? Take => _take;
    }
}
