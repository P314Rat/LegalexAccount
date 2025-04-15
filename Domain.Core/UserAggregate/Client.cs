namespace Domain.Core.UserAggregate
{
    public abstract class Client : User
    {
        public required ClientRole ClientRole { get; set; }
    }
}
