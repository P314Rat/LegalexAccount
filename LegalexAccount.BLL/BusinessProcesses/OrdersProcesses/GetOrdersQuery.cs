using LegalexAccount.BLL.DTO;
using MediatR;


namespace LegalexAccount.BLL.BusinessProcesses.OrdersProcesses
{
    public class GetOrdersQuery : IRequest<List<OrderDTO>>
    {
        public GetOrdersQuery() { }
    }
}
