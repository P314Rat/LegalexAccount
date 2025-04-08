using Utilities.Types;


namespace Application.Core.DTO
{
    public class ProfileDTO
    {
        public string? Email { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? SurName { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Password { get; set; }
        public string? OrganizationName { get; set; }
        public string? LegalAddress { get; set; }
        public string? PostalAddress { get; set; }
        public string? LegalID { get; set; }
        public string? BankAccountNumber { get; set; }
        public string? BankName { get; set; }
        public string? BankAddress { get; set; }
        public string? BankIdenticationCode { get; set; }
        public string? PositionHeld { get; set; }
        public string? Powers { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string? PassportNumber { get; set; }
        public string? IssuingAuthority { get; set; }
        public DateTime? IssueDate { get; set; }
        public string? TaxIdentificationNumber { get; set; }
        public string? RegistrationAddress { get; set; }
        public string? ResidentialAddress { get; set; }
        public SpecialistType? Role { get; set; }
        public SpecialistStatus? Status { get; set; }
    }
}
