using Application.Core.DTO;
using MediatR;


namespace Application.Core.BusinessLogic.OrderProcess.GetOrders
{
    public class GetOrdersQuery : IRequest<List<OrderDTO>>
    {
        public GetOrdersQuery(int skip = 0, int take = 0) { }
    }
}
