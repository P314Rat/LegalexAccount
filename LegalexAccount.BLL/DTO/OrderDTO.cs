using LegalexAccount.Utility.Types;


namespace LegalexAccount.BLL.DTO
{
    public class OrderDTO
    {
        public int Id { get; set; }
        public DateTime? CreatedAt { get; set; } = null;
        public ClientType? ClientType { get; set; } = null;
        public ServiceType? ServiceType { get; set; } = null;
        public string? Name { get; set; } = null;
        public string? Contact { get; set; } = null;
        public string? Description { get; set; } = null;
    }
}
