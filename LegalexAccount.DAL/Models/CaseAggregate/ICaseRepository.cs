namespace LegalexAccount.DAL.Models.CaseAggregate
{
    public interface ICaseRepository
    {
        void Create(Case item);
        Case GetById(int id);
        IEnumerable<Case> GetAll();
        void Delete(Case item);
        void DeleteById(int id);
        void DeleteAll();
        void Update(Case item);

    }
}
