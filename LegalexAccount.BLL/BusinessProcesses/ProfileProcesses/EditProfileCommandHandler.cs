using LegalexAccount.DAL;
using LegalexAccount.DAL.Models.UserAggregate;
using LegalexAccount.DAL.Repositories.Contracts;
using LegalexAccount.Utility.Exceptions;
using LegalexAccount.Utility.Services;
using MediatR;
using Microsoft.EntityFrameworkCore;


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
                if (request.Profile != null)
                {
                    var specialistId = (await _unitOfWork.Specialists.AsQueryable()
                        .FirstOrDefaultAsync(x => x.Email == request.Profile.Email))?.Id;

                    var model = new Specialist
                    {
                        Id = specialistId ?? default,
                        Email = request.Profile.Email,
                        FirstName = request.Profile.FirstName,
                        LastName = request.Profile.LastName,
                        SurName = request.Profile.SurName,
                        PhoneNumber = request.Profile.PhoneNumber
                    };

                    if (request.Profile.OldPassword != null)
                    {
                        var passwordHash = GenerateDataService.GenerateHash(request.Profile.OldPassword, specialist.PasswordSalt);

                        if (passwordHash != specialist.PasswordHash)
                            throw new ValidationException("OldPassword", "Неверный текущий пароль.");

                        const int SALT_SIZE = 32;
                        var salt = GenerateDataService.GenerateSalt(SALT_SIZE);
                        var hash = GenerateDataService.GenerateHash(request.Profile.NewPassword, salt);

                        model.PasswordHash = hash;
                        model.PasswordSalt = salt;
                    }

                    await _unitOfWork.Specialists.UpdateAsync(model);
                }
                else
                {
                    const int SALT_SIZE = 32;
                    var salt = GenerateDataService.GenerateSalt(SALT_SIZE);
                    var hash = GenerateDataService.GenerateHash(request.Password.NewPassword, salt);

                    specialist.PasswordHash = hash;
                    specialist.PasswordSalt = salt;

                    await _unitOfWork.Specialists.UpdateAsync(specialist);
                }


                return;
            }

            var client = (Client?)await ((IUserRepository)_unitOfWork.Clients).GetByEmailAsync(request.UserEmail);

            if (client != null)
            {
                if (request.Profile != null)
                {
                    client.Email = request.Profile.Email;
                    client.FirstName = request.Profile.FirstName;
                    client.LastName = request.Profile.LastName;
                    client.SurName = request.Profile.SurName;
                    client.PhoneNumber = request.Profile.PhoneNumber;

                    if (request.Profile.OldPassword != null)
                    {
                        var passwordHash = GenerateDataService.GenerateHash(request.Profile.OldPassword, specialist.PasswordSalt);

                        if (passwordHash != specialist.PasswordHash)
                            throw new ValidationException("OldPassword", "Неверный текущий пароль.");

                        const int SALT_SIZE = 32;
                        var salt = GenerateDataService.GenerateSalt(SALT_SIZE);
                        var hash = GenerateDataService.GenerateHash(request.Profile.NewPassword, salt);

                        client.PasswordHash = hash;
                        client.PasswordSalt = salt;
                    }
                }
                else
                {
                    const int SALT_SIZE = 32;
                    var salt = GenerateDataService.GenerateSalt(SALT_SIZE);
                    var hash = GenerateDataService.GenerateHash(request.Password.NewPassword, salt);

                    client.PasswordHash = hash;
                    client.PasswordSalt = salt;
                }

                await _unitOfWork.Clients.UpdateAsync(client);
            }
        }
    }
}
