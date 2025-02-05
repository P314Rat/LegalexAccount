using LegalexAccount.BLL.DTO;
using LegalexAccount.BLL.DTO.Case;
using LegalexAccount.DAL;
using LegalexAccount.DAL.Models.UserAggregate;
using LegalexAccount.DAL.Repositories.Contracts;
using Microsoft.AspNetCore.Mvc.Rendering;


namespace LegalexAccount.Web.ViewModels.Case
{
    internal static class CaseViewModelExtension
    {
        internal static CaseViewModel ToViewModel(this CaseDTO model)
        {
            var resultModel = new CaseViewModel
            {
                Id = model.Id,
                StartDate = model.StartDate ?? throw new NullReferenceException(),
                EstimatedDaysToEnd = model.EstimatedDaysToEnd,
                Customer = new SelectListItem
                {
                    Value = model.Customer.Email ?? string.Empty,
                    Text = model.Customer is LegalDTO
                        ? (model.Customer as LegalDTO).OrganizationName
                        : (model.Customer as PersonDTO).FirstName + " " + (model.Customer as PersonDTO).LastName
                },
                Assignees = model.Assignees.Select(x => new SelectListItem
                {
                    Value = x.Email,
                    Text = x.FirstName + " " + x.LastName,
                }).ToList(),
                Description = model.Description ?? string.Empty
            };

            return resultModel;
        }

        internal static async Task<CaseDTO> ToDTO(this CaseViewModel model, IUnitOfWork unitOfWork)
        {
            var user = await ((IUserRepository)unitOfWork.Clients).GetByEmailAsync(model.Customer.Value);

            UserDTO customer = user switch
            {
                Legal => new LegalDTO
                {
                    Email = user.Email,
                    PhoneNumber = user.PhoneNumber,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    SurName = user.SurName,
                    OrganizationName = ((Legal)user).OrganizationName,
                    LegalAddress = ((Legal)user).LegalAddress,
                    PostalAddress = ((Legal)user).PostalAddress,
                    LegalID = ((Legal)user).LegalID,
                    BankAccountNumber = ((Legal)user).BankAccountNumber,
                    BankName = ((Legal)user).BankName,
                    BankAddress = ((Legal)user).BankAddress,
                    BankIdenticationCode = ((Legal)user).BankIdenticationCode,
                    PositionHeld = ((Legal)user).PositionHeld,
                    Powers = ((Legal)user).Powers
                },
                Person => new PersonDTO
                {
                    Email = user.Email,
                    PhoneNumber = user.PhoneNumber,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    SurName = user.SurName,
                    DateOfBirth = ((Person)user).DateOfBirth,
                    PassportNumber = ((Person)user).PassportNumber,
                    IssuingAuthority = ((Person)user).IssuingAuthority,
                    IssueDate = ((Person)user).IssueDate,
                    TaxIdentificationNumber = ((Person)user).TaxIdentificationNumber,
                    RegistrationAddress = ((Person)user).RegistrationAddress,
                    ResidentialAddress = ((Person)user).ResidentialAddress
                },
                _ => throw new NotImplementedException(),
            };

            var specialistsQuery = unitOfWork.Specialists.AsQueryable();

            var specialists = model.Assignees
                .Select(x => specialistsQuery.FirstOrDefault(t => t.Email == x.Value))
                .Select(x => new SpecialistDTO
                {
                    Email = x.Email,
                    PhoneNumber = x.PhoneNumber,
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    SurName = x.SurName,
                    Role = x.Role,
                    Status = x.Status
                })
                .ToList();

            var resultModel = new CaseDTO
            {
                Id = model.Id,
                StartDate = model.StartDate,
                EstimatedDaysToEnd = model.EstimatedDaysToEnd,
                Customer = customer,
                Assignees = specialists,
                Description = model.Description
            };

            return resultModel;
        }

        internal static async Task<CaseDTO> ToDTO(this CreateCaseViewModel model, IUnitOfWork unitOfWork)
        {
            var user = await ((IUserRepository)unitOfWork.Clients).GetByEmailAsync(model.Customer);

            UserDTO customer = user switch
            {
                Legal => new LegalDTO
                {
                    Email = user.Email,
                    PhoneNumber = user.PhoneNumber,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    SurName = user.SurName,
                    OrganizationName = ((Legal)user).OrganizationName,
                    LegalAddress = ((Legal)user).LegalAddress,
                    PostalAddress = ((Legal)user).PostalAddress,
                    LegalID = ((Legal)user).LegalID,
                    BankAccountNumber = ((Legal)user).BankAccountNumber,
                    BankName = ((Legal)user).BankName,
                    BankAddress = ((Legal)user).BankAddress,
                    BankIdenticationCode = ((Legal)user).BankIdenticationCode,
                    PositionHeld = ((Legal)user).PositionHeld,
                    Powers = ((Legal)user).Powers
                },
                Person => new PersonDTO
                {
                    Email = user.Email,
                    PhoneNumber = user.PhoneNumber,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    SurName = user.SurName,
                    DateOfBirth = ((Person)user).DateOfBirth,
                    PassportNumber = ((Person)user).PassportNumber,
                    IssuingAuthority = ((Person)user).IssuingAuthority,
                    IssueDate = ((Person)user).IssueDate,
                    TaxIdentificationNumber = ((Person)user).TaxIdentificationNumber,
                    RegistrationAddress = ((Person)user).RegistrationAddress,
                    ResidentialAddress = ((Person)user).ResidentialAddress
                },
                _ => throw new NotImplementedException(),
            };

            var specialistsQuery = unitOfWork.Specialists.AsQueryable();

            var specialists = model.Assignees
                .Select(x => specialistsQuery.FirstOrDefault(t => t.Email == x))
                .Select(x => new SpecialistDTO
                {
                    Email = x.Email,
                    PhoneNumber = x.PhoneNumber,
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    SurName = x.SurName,
                    Role = x.Role,
                    Status = x.Status
                })
                .ToList();

            var resultModel = new CaseDTO
            {
                StartDate = model.StartDate,
                EstimatedDaysToEnd = model.EstimatedDaysToEnd,
                Customer = customer,
                Assignees = specialists,
                Description = model.Description
            };

            return resultModel;
        }

    }
}
