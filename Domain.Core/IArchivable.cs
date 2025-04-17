namespace Domain.Core
{
    public interface IArchivable
    {
        bool IsArchived { get; set; }
        DateTime? ArchivedAt { get; set; }
    }
}
