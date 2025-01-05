using LegalexAccount.BLL.BusinessProcesses.ClientsProcesses;
using LegalexAccount.BLL.BusinessProcesses.EmployeesProcesses;
using LegalexAccount.BLL.DTO;
using LegalexAccount.DAL;
using LegalexAccount.Web.ViewModels;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections;


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
            var clients = await _mediator.Send(new GetClientsQuery());

            ViewBag.Clients = new List<SelectListItem>
            {
                new SelectListItem { Value = "", Text = "Выберите заказчика", Selected = true }
            }
            .Concat(
                (await _mediator.Send(new GetClientsQuery())).Select(x => new SelectListItem
                {
                    Value = x.Email,
                    Text = (x as LegalDTO)?.OrganizationName != null ? (x as LegalDTO)?.OrganizationName : x.FirstName + ' ' + x.LastName
                }).ToList());

            ViewBag.Assignee = (await _mediator.Send(new GetEmployeesQuery()))
                .Select(x => new SelectListItem
                {
                    Value = x.Email,
                    Text = x.FirstName + ' ' + x.LastName
                }).ToList();

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
