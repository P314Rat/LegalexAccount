using LegalexAccount.DAL;
using LegalexAccount.DAL.Models.UserAggregate;
using LegalexAccount.DAL.Repositories.Contracts;
using LegalexAccount.Utility.Exceptions;
using LegalexAccount.Utility.Services;
using MediatR;


namespace LegalexAccount.BLL.BusinessProcesses.ProfileProcesses
{
    public class EditProfileCommandHandler : IRequestHandler<EditProfileCommand>
    {
        private readonly IUnitOfWork _unitOfWork;


        public EditProfileCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(EditProfileCommand request, CancellationToken cancellationToken)
        {
            var specialist = (Specialist?)await ((IUserRepository)_unitOfWork.Specialists).GetByEmailAsync(request.UserEmail);

            if (specialist != null)
            {
                specialist.Email = request.Model.Email;
                specialist.FirstName = request.Model.FirstName;
                specialist.LastName = request.Model.LastName;
                specialist.SurName = request.Model.SurName;
                specialist.PhoneNumber = request.Model.PhoneNumber;

                var passwordHash = GenerateDataService.GenerateHash(request.Model.OldPassword, specialist.PasswordSalt);

                if (passwordHash != specialist.PasswordHash)
                    throw new ValidationException("OldPassword", "Неверный текущий пароль.");

                const int SALT_SIZE = 32;
                var salt = GenerateDataService.GenerateSalt(SALT_SIZE);
                var hash = GenerateDataService.GenerateHash(request.Model.NewPassword, salt);

                specialist.PasswordHash = hash;
                specialist.PasswordSalt = salt;

                await _unitOfWork.Specialists.UpdateAsync(specialist);

                return;
            }

            var client = (Client?)await ((IUserRepository)_unitOfWork.Clients).GetByEmailAsync(request.UserEmail);

            if (client != null)
            {
                client.Email = request.Model.Email;
                client.FirstName = request.Model.FirstName;
                client.LastName = request.Model.LastName;
                client.SurName = request.Model.SurName;
                client.PhoneNumber = request.Model.PhoneNumber;

                await _unitOfWork.Clients.UpdateAsync(client);
            }
        }
    }
}
