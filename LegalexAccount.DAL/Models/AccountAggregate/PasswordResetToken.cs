namespace LegalexAccount.DAL.Models.AccountAggregate
{
    public class PasswordResetToken : BaseEntity<int>
    {
        public string Email { get; set; } // Email пользователя
        public string Token { get; set; } // Уникальный токен
        public DateTime ExpirationDate { get; set; } // Время жизни токена
        public bool IsUsed { get; set; } // Был ли уже использован
    }
}
