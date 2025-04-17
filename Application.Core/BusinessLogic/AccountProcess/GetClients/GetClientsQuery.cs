using Application.Core.DTO;
using MediatR;
using Utilities.Types;


namespace Application.Core.BusinessLogic.AccountProcess.GetClients
{
    public class GetClientsQuery : IRequest<PagedResult<ProfileDTO>>
    {
        public int Skip { get; }
        public int Take { get; }


        public GetClientsQuery(int skip, int take)
        {
            Skip = skip;
            Take = take;
        }
    }
}
