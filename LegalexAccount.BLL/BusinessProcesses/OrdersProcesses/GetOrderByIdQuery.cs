using LegalexAccount.BLL.DTO;
using MediatR;


namespace LegalexAccount.BLL.BusinessProcesses.OrdersProcesses
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
