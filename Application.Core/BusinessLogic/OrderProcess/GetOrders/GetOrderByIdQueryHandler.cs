using Application.Core.DTO;
using AutoMapper;
using Domain.Core.OrderAggregate;
using Infrastructure.Specifications.OrderAggregate;
using MediatR;
using Utilities.Types;

namespace Application.Core.BusinessLogic.OrderProcess.GetOrders
{
    public class GetOrderByIdQueryHandler : IRequestHandler<GetOrderByIdQuery, OrderDTO>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;


        public GetOrderByIdQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<OrderDTO> Handle(GetOrderByIdQuery request, CancellationToken cancellationToken)
        {
            var order = (await _unitOfWork.Repository<Order, int>()
                .GetAsync(new OrderByIdSpecification(request.Id)))
                .FirstOrDefault();

            return _mapper.Map<OrderDTO>(order);
        }
    }
}
