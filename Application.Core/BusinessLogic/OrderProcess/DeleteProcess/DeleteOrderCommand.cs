using MediatR;


namespace Application.Core.BusinessLogic.OrderProcess.DeleteProcess
{
    public class DeleteOrderCommand : IRequest
    {
        public int Id { get; set; }


        public DeleteOrderCommand(int id)
        {
            Id = id;
        }
    }
}
