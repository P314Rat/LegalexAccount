using LegalexAccount.Utility.Types;


namespace LegalexAccount.BLL.DTO
{
    public class OrderDTO
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public ClientType ClientType { get; set; }
        public ServiceType Service { get; set; }
        public string Name { get; set; }
        public string Contact { get; set; }
        public string Description { get; set; }
    }
}
