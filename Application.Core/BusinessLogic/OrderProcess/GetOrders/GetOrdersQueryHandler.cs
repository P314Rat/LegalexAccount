using Application.Core.DTO;
using AutoMapper;
using Infrastructure;
using MediatR;


namespace Application.Core.BusinessLogic.OrderProcess.GetOrders
{
    public class GetOrdersQueryHandler : IRequestHandler<GetOrdersQuery, List<OrderDTO>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;


        public GetOrdersQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<List<OrderDTO>> Handle(GetOrdersQuery request, CancellationToken cancellationToken)
        {
            var orders = await _unitOfWork.Orders.GetAsync();
            var result = orders.Select(_mapper.Map<OrderDTO>).ToList();

            return result;
        }
    }
}
