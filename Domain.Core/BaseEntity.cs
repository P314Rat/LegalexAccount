namespace Domain.Core
{
    public abstract class BaseEntity<TId>
    {
        public required TId Id { get; set; }
    }
}
