using LegalexAccount.BLL.DTO;
using MediatR;


namespace LegalexAccount.BLL.BusinessProcesses.OrdersProcesses
{
    public class GetOrdersQuery : IRequest<List<OrderDTO>>
    {
        public int Id { get; set; }


        public GetOrdersQuery(int id = 0)
        {
            Id = id;
        }
    }
}
