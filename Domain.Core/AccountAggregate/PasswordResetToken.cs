namespace Domain.Core.AccountAggregate
{
    public class PasswordResetToken : BaseEntity<int>
    {
        public required string Email { get; set; }
        public required string Token { get; set; }
        public required DateTime ExpirationDate { get; set; }
        public required bool IsUsed { get; set; }
    }
}
