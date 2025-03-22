using Domain.Core.CaseAggregate;
using Utilities.Types;


namespace Application.Core.DTO.UserAggreagate
{
    public class SpecialistDTO : UserDTO
    {
        public List<Case>? Cases { get; set; }
        public required SpecialistType Role { get; set; }
        public required SpecialistStatus Status { get; set; }
    }
}
