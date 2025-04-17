using Application.Core.DTO;
using MediatR;


namespace Application.Core.BusinessLogic.OrderProcess.GetOrders
{
    public class GetOrderByIdQuery : IRequest<OrderDTO>
    {
        public int Id { get; set; }


        public GetOrderByIdQuery(int id)
        {
            Id = id;
        }
    }
}
