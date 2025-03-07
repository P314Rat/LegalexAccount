namespace Application.Core.DTO
{
    public abstract class ClientDTO : UserDTO
    {
        public List<CaseDTO>? Cases { get; set; }
    }
}
