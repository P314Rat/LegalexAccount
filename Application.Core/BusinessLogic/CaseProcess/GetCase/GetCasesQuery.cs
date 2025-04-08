using Application.Core.DTO;
using Domain.Core.CaseAggregate;
using MediatR;
using Utilities.Types;


namespace Application.Core.BusinessLogic.CaseProcess.GetCase
{
    public class GetCasesQuery : IRequest<List<CaseDTO>>
    {
        public UserRole UserRole { get; set; }
        public string? CurrentUserEmail { get; set; }


        public GetCasesQuery(UserRole userRole, string? currentUserEmail)
        {
            UserRole = userRole;
            CurrentUserEmail = currentUserEmail;
        }
    }
}
