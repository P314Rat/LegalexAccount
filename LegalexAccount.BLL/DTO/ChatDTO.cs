using LegalexAccount.DAL.Models.UserAggregate;


namespace LegalexAccount.BLL.DTO
{
    public class ChatDTO
    {
        public string Name { get; set; }
        public List<UserDTO> Members { get; set; }
        public List<MessageDTO> Messages { get; set; }
    }
}
