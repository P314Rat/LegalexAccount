using Domain.Core.CaseAggregate;


namespace Domain.Core.UserAggregate
{
    public abstract class Client : User
    {
        public List<Case>? Cases { get; set; }
    }
}
