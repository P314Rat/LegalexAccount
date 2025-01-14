using LegalexAccount.BLL.BusinessProcesses.EmployeesProcesses;
using LegalexAccount.DAL;
using LegalexAccount.Web.ViewModels;
using MediatR;
using Microsoft.AspNetCore.Mvc;


namespace LegalexAccount.Web.Controllers
{
    public class SpecialistController : BaseController
    {
        private readonly IMediator _mediator;


        public SpecialistController(IMediator mediator, IApplicationDbContextFactory _dbContextFactory,
            IHttpContextAccessor httpContextAccessor) : base(_dbContextFactory, httpContextAccessor)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<JsonResult> GetEmployees()
        {
            var clients = (await _mediator.Send(new GetEmployeesQuery())).Select(x => new ProfileViewModel
            {
                Email = x.Email,
                FirstName = x.FirstName,
                LastName = x.LastName
            }).ToArray();

            return Json(clients);
        }

        [HttpGet]
        public async Task<IActionResult> EmployeesCard(string email)
        {
            try
            {
                ViewData["ProfileModel"] = _profileModel;
                var specialist = (await _mediator.Send(new GetEmployeesByEmailQuery(email)))?.ToViewModel();

                if (specialist == null)
                    throw new Exception("Specialist not found");

                return View(specialist);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
