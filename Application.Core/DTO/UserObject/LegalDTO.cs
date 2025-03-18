namespace Application.Core.DTO.UserObject
{
    public class LegalDTO : ClientDTO
    {
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
    }
}
