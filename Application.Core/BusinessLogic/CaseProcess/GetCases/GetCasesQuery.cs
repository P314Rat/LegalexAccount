using Application.Core.DTO;
using MediatR;
using Utilities.Types;


namespace Application.Core.BusinessLogic.CaseProcess.GetCase
{
    public class GetCasesQuery : IRequest<PagedResult<CaseDTO>>
    {
        public string? CurrentUserEmail { get; set; }
        public int Skip { get; }
        public int Take { get; }


        public GetCasesQuery(int skip, int take, string? currentUserEmail)
        {
            CurrentUserEmail = currentUserEmail;
            Skip = skip;
            Take = take;
        }
    }
}
