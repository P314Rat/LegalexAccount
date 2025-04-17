using Application.Core.DTO;
using AutoMapper;
using Domain.Core.OrderAggregate;
using Infrastructure.Specifications.OrderAggregate;
using MediatR;
using Utilities.Types;


namespace Application.Core.BusinessLogic.OrderProcess.GetOrders
{
    public class GetOrdersQueryHandler : IRequestHandler<GetOrdersQuery, PagedResult<OrderDTO>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;


        public GetOrdersQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<PagedResult<OrderDTO>> Handle(GetOrdersQuery request, CancellationToken cancellationToken)
        {
            var totalOrdersCount = await _unitOfWork.Repository<Order, int>().CountAsync(new OrderSpecification(request.Skip, request.Take));
            var orders = (await _unitOfWork.Repository<Order, int>()
                .GetAsync(new OrderSpecification(request.Skip, request.Take)))
                .Select(_mapper.Map<OrderDTO>);
            var result = PagedResult<OrderDTO>.Create(orders, totalOrdersCount, request.Take, request.Skip / request.Take + 1);

            return result;
        }
    }
}
