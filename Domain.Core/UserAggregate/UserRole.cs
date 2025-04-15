namespace Domain.Core.UserAggregate
{
    public class UserRole
    {
        public Utilities.Types.UserRole UserRoleId { get; set; }
        public required string Name { get; set; }
    }
}
