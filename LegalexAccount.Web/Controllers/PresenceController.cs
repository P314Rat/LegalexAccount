using MediatR;
using Microsoft.AspNetCore.Mvc;
using LegalexAccount.BLL.BusinessProcesses.PresenceTrackProcess;


namespace LegalexAccount.Web.Controllers
{
    [Route("api/presence")]
    [ApiController]
    public class PresenceController : BaseController
    {
        private readonly IMediator _mediator;


        public PresenceController(IMediator mediator, IHttpContextAccessor httpContextAccessor) : base(mediator, httpContextAccessor)
        {
        }

        [HttpGet("online-users")]
        public async Task<ActionResult<List<string>>> GetOnlineUsers()
        {
            var users = await _mediator.Send(new GetOnlineUsersQuery());
            return Ok(users);
        }
    }
}
