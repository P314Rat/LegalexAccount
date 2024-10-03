namespace LegalexAccount.DAL.Models.UserAggregate
{
    public interface ISpecialistRepository
    {
        void Create(Specialist item);
        Specialist GetById(string id);
        IEnumerable<Specialist> GetAll();
        void Delete(Specialist item);
        void DeleteById(string id);
        void DeleteAll();
        void Update(Specialist item);
    }
}
