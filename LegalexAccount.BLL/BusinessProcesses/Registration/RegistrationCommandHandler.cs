using LegalexAccount.BLL.DTO;
using LegalexAccount.BLL.Services;
using LegalexAccount.DAL;
using LegalexAccount.DAL.Models.UserAggregate;
using LegalexAccount.Utility.Types;
using MediatR;
using System.Data;


namespace LegalexAccount.BLL.BusinessProcesses.Registration
{
    public class RegistrationCommandHandler : IRequestHandler<RegistrationCommand>
    {
        private readonly IUnitOfWork _unitOfWork;


        public RegistrationCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(RegistrationCommand command, CancellationToken cancellationToken)
        {
            //var isUserExists = _unitOfWork.Users.IsExists(command.Email);

            //if (isUserExists)
            //    throw new DuplicateNameException("User is exists");

            //var salt = GenerateDataService.CreateSalt(32);

            //if (salt == null)
            //    throw new InvalidOperationException("Salt was not generated");

            //var hashedPassword = GenerateDataService.GenerateHash(command.Password, salt);

            //if (salt == null)
            //    throw new InvalidOperationException("Password was not hashed");

            //if (command.UserType == UserType.Specialist)
            //{
            //    var user = new Specialist
            //    {
            //        Status = SpecialistStatus.Free,
            //        Email = command.Email,
            //        Phone = command.Phone,
            //        PasswordHash = hashedPassword,
            //        PasswordSalt = salt,
            //        FirstName = command.FirstName,
            //        LastName = command.LastName,
            //        SurName = command.SurName
            //    };

            //    _unitOfWork.Specialists.Create(user);
            //}
            //else if (command.UserType == UserType.Person)
            //{
            //    var user = new Person
            //    {

            //    };

            //    _unitOfWork.Individuals.Create(user);
            //}
            //else if (command.UserType == UserType.Legal)
            //{
            //    var user = new Legal
            //    {

            //    };

            //    _unitOfWork.LegalEntities.Create(user);
            //}

            //_unitOfWork.SaveChanges();
        }
    }
}
