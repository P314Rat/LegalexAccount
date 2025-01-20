using LegalexAccount.BLL.DTO;
using LegalexAccount.DAL;
using MediatR;
using Microsoft.EntityFrameworkCore;


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
            var ordersQuery = _unitOfWork.Orders.AsQueryable();

            if (ordersQuery.Any())
            {
                var orders = await ordersQuery.Select(x => x.ToDTO()).ToListAsync();

                return orders;
            }

            return new List<OrderDTO>();
        }
    }
}
