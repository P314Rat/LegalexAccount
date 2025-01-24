using LegalexAccount.BLL.DTO;
using MediatR;


namespace LegalexAccount.BLL.BusinessProcesses.SpecialistsProcesses
{
    public class EditEmployeeQuery : IRequest
    {
        public SpecialistDTO Model { get; set; }
        public MailRequest MailRequest { get; set; }


        public EditEmployeeQuery(SpecialistDTO model, MailRequest mailRequest)
        {
            Model = model;
            MailRequest = mailRequest;
        }
    }
}
