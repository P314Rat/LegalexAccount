namespace LegalexAccount.BLL.DTO
{
    public class ClientDTO
    {
        public string Email { get; set; } = string.Empty;
        public string? Phone { get; set; } = null;
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string SurName { get; set; } = string.Empty;
    }
}
