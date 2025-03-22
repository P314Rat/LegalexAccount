using Application.Core.DTO.CaseObject;

namespace Application.Core.DTO.UserAggreagate
{
    public class ClientDTO : UserDTO
    {
        public List<CaseDTO>? Cases { get; set; }
    }
}
