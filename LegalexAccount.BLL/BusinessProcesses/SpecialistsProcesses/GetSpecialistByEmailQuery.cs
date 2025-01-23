using LegalexAccount.BLL.DTO;
using MediatR;


namespace LegalexAccount.BLL.BusinessProcesses.SpecialistsProcesses
{
    public class GetSpecialistByEmailQuery : IRequest<SpecialistDTO?>
    {
        public string Email { get; set; }


        public GetSpecialistByEmailQuery(string email)
        {
            Email = email;
        }
    }
}
