using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Presentation.ViewModels.EditProfile;


namespace Presentation.Controllers
{
    [Authorize]
    public class ProfileController : BaseController
    {
        public ProfileController(IMediator mediator, IHttpContextAccessor httpContextAccessor) : base(mediator, httpContextAccessor)
        {
        }

        [HttpPost]
        public IActionResult UpdateGeneral(GeneralViewModel model)
        {
            return Ok();
        }

        [HttpPost]
        public IActionResult UpdateOrganization(GeneralViewModel model)
        {
            return Ok();
        }
        [HttpPost]
        public IActionResult UpdateBankAccount(GeneralViewModel model)
        {
            return Ok();
        }
        [HttpPost]
        public IActionResult UpdateDocuments(GeneralViewModel model)
        {
            return Ok();
        }
        [HttpPost]
        public IActionResult UpdateSecurity(GeneralViewModel model)
        {
            return Ok();
        }
    }
}
