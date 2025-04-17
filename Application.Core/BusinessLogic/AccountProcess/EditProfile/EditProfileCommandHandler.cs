using AutoMapper;
using Domain.Core.UserAggregate;
using Infrastructure.Contracts;
using MediatR;


namespace Application.Core.BusinessLogic.AccountProcess.EditProfile
{
    public class EditProfileCommandHandler : IRequestHandler<EditProfileCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;


        public EditProfileCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task Handle(EditProfileCommand command, CancellationToken cancellationToken)
        {
            //_mapper.Map(profile, command.Profile);

            //User result = profile switch
            //{
            //    Specialist => _mapper.Map<Specialist>(command.Profile),
            //    Legal => _mapper.Map<Legal>(profile),
            //    Person => _mapper.Map<Person>(profile),
            //    _ => throw new InvalidCastException()
            //};

            //await _unitOfWork.Users.UpdateAsync(result);

            throw new NotImplementedException();
        }
    }
}
