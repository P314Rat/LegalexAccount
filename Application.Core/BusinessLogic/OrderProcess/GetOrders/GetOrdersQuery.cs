using Application.Core.DTO;
using MediatR;
using Utilities.Types;


namespace Application.Core.BusinessLogic.OrderProcess.GetOrders
{
    public class GetOrdersQuery : IRequest<PagedResult<OrderDTO>>
    {
        public int Skip { get; }
        public int Take { get; }


        public GetOrdersQuery(int skip, int take)
        {
            Skip = skip;
            Take = take;
        }
    }
}
