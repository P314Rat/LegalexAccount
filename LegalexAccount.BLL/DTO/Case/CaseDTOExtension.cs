using LegalexAccount.DAL;
using Microsoft.EntityFrameworkCore;


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

            var customer = await unitOfWork.Clients.AsQueryable().Where(x => x.Email == model.CustomerEmail).FirstOrDefaultAsync();
            var assignee = await unitOfWork.Specialists.AsQueryable().Where(x => x.Email == model.AssigneeEmail).FirstOrDefaultAsync();
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
            var resultModel = new CaseDTO
            {
                StartDate = model.StartDate,
                EstimatedDaysToEnd = model.EstimatedDaysToEnd,
                CustomerEmail = model.Customer.Email,
                AssigneeEmail = model.Assignee.Email,
                Description = model.Description ?? string.Empty
            };

            return resultModel;
        }
    }
}
