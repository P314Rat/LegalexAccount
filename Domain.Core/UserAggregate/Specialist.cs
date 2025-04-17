using Utilities.Types;


namespace Domain.Core.UserAggregate
{
    public class Specialist : User
    {
        public required SpecialistRole SpecialistRole { get; set; }
        public SpecialistStatus Status { get; set; } 
    }
}
