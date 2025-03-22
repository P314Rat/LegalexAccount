using Utilities.Types;


namespace Domain.Core.UserAggregate
{
    public class Specialist : User
    {
        public required SpecialistType Role { get; set; }
        public required SpecialistStatus Status { get; set; }
    }
}
