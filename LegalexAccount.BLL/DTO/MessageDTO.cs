namespace LegalexAccount.BLL.DTO
{
    public class MessageDTO
    {
        public UserDTO Sender { get; set; }
        public string Text { get; set; }
        public DateTime SendedAt { get; set; }
    }
}
