namespace Application.Core.DTO
{
    public abstract class UserDTO
    {
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? SurName { get; set; }
        public string? Password { get; set; }
    }
}
