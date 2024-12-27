using LegalexAccount.BLL.DTO;
using LegalexAccount.DAL;
using LegalexAccount.DAL.Models.OrderAggregate;
using MediatR;


namespace LegalexAccount.BLL.BusinessProcesses.OrdersProcesses
{
    public class GetOrdersQueryHandler : IRequestHandler<GetOrdersQuery, List<OrderDTO>>
    {
        private readonly IUnitOfWork _unitOfWork;


        public GetOrdersQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<OrderDTO>> Handle(GetOrdersQuery request, CancellationToken cancellationToken)
        {
            var orders = new List<Order>();

            if (request.Id > 0)
                orders.Add(await _unitOfWork.Orders.GetByIdAsync(request.Id));
            else
                orders = (await _unitOfWork.Orders.GetAllAsync()).ToList();

            var ordersDTO = orders.Select(x => x.ToDTO()).ToList();

            return ordersDTO;
        }
    }
}
