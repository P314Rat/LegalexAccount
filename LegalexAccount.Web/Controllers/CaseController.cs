using LegalexAccount.DAL.Models;
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
                ViewData["StepNumber"] = 1;

                return View();
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
