using LegalexAccount.DAL;
using LegalexAccount.DAL.Models.UserAggregate;
using Microsoft.EntityFrameworkCore;


namespace LegalexAccount.BLL.DTO.Case
{
    internal static class CaseDTOExtension
    {
        internal static async Task<DAL.Models.CaseAggregate.Case> ToModel(this CaseDTO model, IUnitOfWork unitOfWork)
        {
            if (model == null)
                throw new Exception("CaseDTO is null");

            if (model.Customer == null || model.Assignees == null)
                throw new Exception("CaseDTO model is wrong");

            var customer = await unitOfWork.Clients.AsQueryable()
                .Where(x => x.Email == model.Customer.Email)
                .FirstOrDefaultAsync();

            var emails = model.Assignees.Select(x => x.Email);
            var assignees = await unitOfWork.Specialists.AsQueryable()
                .Where(x => emails.Contains(x.Email))
                .ToListAsync();


            var resultModel = new DAL.Models.CaseAggregate.Case
            {
                StartDate = model.StartDate ?? DateTime.Now,
                EstimatedDaysToEnd = model.EstimatedDaysToEnd,
                CustomerId = customer?.Id ?? throw new Exception("Guid isn't exists"),
                Customer = customer ?? throw new Exception("Wrong customer"),
                Assignees = assignees ?? throw new Exception("Wrong assignee"),
                Description = model.Description ?? string.Empty
            };

            return resultModel;
        }

        internal static CaseDTO ToDTO(this DAL.Models.CaseAggregate.Case model)
        {
            var resultModel = new CaseDTO
            {
                Id = model.Id,
                StartDate = model.StartDate,
                EstimatedDaysToEnd = model.EstimatedDaysToEnd,
                Customer = model.Customer is Legal ? (model.Customer as Legal).ToDTO()
                : (model.Customer as Person).ToDTO(),
                Assignees = model.Assignees.Select(x => x.ToDTO()).ToList(),
                Description = model.Description ?? string.Empty
            };

            return resultModel;
        }
    }
}
