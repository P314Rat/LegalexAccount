using LegalexAccount.DAL;
using LegalexAccount.DAL.Models.UserAggregate;
using LegalexAccount.DAL.Repositories.Contracts;


namespace LegalexAccount.BLL.DTO.Case
{
    internal static class CaseDTOExtension
    {
        internal static async Task<DAL.Models.CaseAggregate.Case> ToModel(this CaseDTO model, IUnitOfWork unitOfWork)
        {
            if (model == null)
                throw new Exception("CaseDTO is null");

            if (model.CustomerEmail == null || model.AssigneeEmail == null)
                throw new Exception("CaseDTO model is wrong");

            var clientsRepository = unitOfWork.Clients;
            var customer = await ((IUserRepository)clientsRepository).GetByEmailAsync(model.CustomerEmail) as Client;

            var employeesRepository = unitOfWork.Specialists;
            var assignee = await ((IUserRepository)employeesRepository).GetByEmailAsync(model.AssigneeEmail) as Specialist;


            var resultModel = new DAL.Models.CaseAggregate.Case
            {
                StartDate = model.StartDate ?? DateTime.Now,
                EstimatedDaysToEnd = model.EstimatedDaysToEnd,
                CustomerId = customer?.Id ?? throw new Exception("Guid isn't exists"),
                Customer = customer ?? throw new Exception("Wrong customer"),
                AssigneeId = assignee?.Id ?? throw new Exception("Guid isn't exists"),
                Assignee = assignee ?? throw new Exception("Wrong assignee"),
                Description = model.Description ?? string.Empty
            };

            return resultModel;
        }

        internal static CaseDTO ToDTO(this DAL.Models.CaseAggregate.Case model)
        {
            throw new NotImplementedException();
        }
    }
}
