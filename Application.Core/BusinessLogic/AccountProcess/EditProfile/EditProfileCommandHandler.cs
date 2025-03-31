using AutoMapper;
using Domain.Core.UserAggregate;
using Infrastructure;
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
            await _unitOfWork.Users.UpdateAsync(_mapper.Map<User>(command.Profile));
        }
    }
}
