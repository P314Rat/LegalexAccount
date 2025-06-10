using AutoMapper;
using Domain.Core.UserAggregate;
using Infrastructure.Contracts;
using Infrastructure.Specifications.UserAggregate;
using MediatR;


namespace Application.Core.BusinessLogic.AccountProcess.EditProfile
{
    public class EditGeneralCommandHandler : IRequestHandler<EditGeneralCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;


        public EditGeneralCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task Handle(EditGeneralCommand command, CancellationToken cancellationToken)
        {
            //var profile = command.Profile;

            //User result = profile switch
            //{
            //    Specialist => _mapper.Map<Specialist>(command.Profile),
            //    Legal => _mapper.Map<Legal>(profile),
            //    Person => _mapper.Map<Person>(profile),
            //    _ => throw new InvalidCastException()
            //};

            //await _unitOfWork.Repository<User, Guid>().UpdateAsync(user, new UserByEmailSpecification(profile.Email));

            throw new NotImplementedException();
        }
    }
}
