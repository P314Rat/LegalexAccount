using LegalexAccount.BLL.BusinessProcesses.Identification;
using LegalexAccount.Web.ViewModels;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;


namespace LegalexAccount.Web.Controllers
{
    [Authorize]
    public class CaseController : Controller
    {
        private readonly IMediator _mediator;
        private static ProfileViewModel? _userModel = null;


        public CaseController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> CreateCase(bool isLegal = true)
        {
            var email = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Name)?.Value;

            if (email == null)
                return BadRequest("Authorization is wrong.");

            try
            {
                _userModel = (await _mediator.Send(new IdentificationQuery(email))).ToViewModel();

                ViewData["UserViewModel"] = _userModel;
                ViewData["StepNumber"] = 1;
                ViewData["IsLegalProfile"] = isLegal;

                return View();
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
