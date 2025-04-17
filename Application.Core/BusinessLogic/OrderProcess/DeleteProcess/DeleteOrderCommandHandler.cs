using Domain.Core.OrderAggregate;
using Infrastructure;
using Infrastructure.Specifications.OrderAggregate;
using MediatR;


namespace Application.Core.BusinessLogic.OrderProcess.DeleteProcess
{
    public class DeleteOrderCommandHandler : IRequestHandler<DeleteOrderCommand>
    {
        private readonly IUnitOfWork _unitOfWork;


        public DeleteOrderCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(DeleteOrderCommand request, CancellationToken cancellationToken)
        {
            await _unitOfWork.Repository<Order, int>().DeleteAsync(new DeleteOrderByIdSpecification(request.Id));
            await _unitOfWork.SaveChangesAsync();
        }
    }
}
