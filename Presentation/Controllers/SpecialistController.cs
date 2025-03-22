using MediatR;


namespace Presentation.Controllers
{
    public class SpecialistController : BaseController
    {
        public SpecialistController(IMediator mediator, IHttpContextAccessor httpContextAccessor) : base(mediator, httpContextAccessor)
        {
        }
    }
}
