namespace LegalexAccount.DAL.Models.AccountAggregate
{
    public class PasswordResetToken
    {
        public int Id { get; set; }
        public string Email { get; set; } // Email пользователя
        public string Token { get; set; } // Уникальный токен
        public DateTime ExpiryDate { get; set; } // Время жизни токена
        public bool IsUsed { get; set; } // Был ли уже использован
    }
}
