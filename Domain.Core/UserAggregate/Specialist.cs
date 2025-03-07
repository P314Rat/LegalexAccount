using Domain.Core.CaseAggregate;
using Utilities.Types;


namespace Domain.Core.UserAggregate
{
    public class Specialist : User
    {
        public List<Case>? Cases { get; set; }
        public required SpecialistType Role { get; set; }
        public required SpecialistStatus Status { get; set; }
    }
}
