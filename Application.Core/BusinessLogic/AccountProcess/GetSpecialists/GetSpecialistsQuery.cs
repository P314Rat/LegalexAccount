using Application.Core.DTO;
using MediatR;
using Utilities.Types;


namespace Application.Core.BusinessLogic.AccountProcess.GetSpecialists
{
    public class GetSpecialistsQuery : IRequest<PagedResult<ProfileDTO>>
    {
        public int Skip { get; }
        public int Take { get; }


        public GetSpecialistsQuery(int skip, int take)
        {
            Skip = skip;
            Take = take;
        }
    }
}
