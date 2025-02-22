namespace LegalexAccount.DAL.Models.AccountAggregate
{
    public class PasswordResetToken : BaseEntity<int>
    {
        public string Email { get; set; }
        public string Token { get; set; }
        public DateTime ExpirationDate { get; set; }
        public bool IsUsed { get; set; }
    }
}
