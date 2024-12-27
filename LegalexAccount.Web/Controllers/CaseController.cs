using LegalexAccount.DAL;
using LegalexAccount.Web.ViewModels;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace LegalexAccount.Web.Controllers
{
    [Authorize]
    public class CaseController : BaseController
    {
        private readonly IMediator _mediator;


        public CaseController(IMediator mediator, IApplicationDbContextFactory _dbContextFactory, IHttpContextAccessor httpContextAccessor)
            : base(_dbContextFactory, httpContextAccessor)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> CreateCase()
        {
            try
            {
                const int stepNumber = 1;
                ViewData["ProfileModel"] = _profileModel;

                return View(stepNumber);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> StepTwo(CaseViewModel model)
        {
            try
            {
                const int stepNumber = 2;
                ViewData["ProfileModel"] = _profileModel;

                return View("CreateCase", stepNumber);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
    }
}
