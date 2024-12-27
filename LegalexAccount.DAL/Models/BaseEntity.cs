namespace LegalexAccount.DAL.Models
{
    public abstract class BaseEntity<TId>
    {
        public TId Id { get; set; }
    }
}
