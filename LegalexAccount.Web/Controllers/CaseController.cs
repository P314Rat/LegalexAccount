using LegalexAccount.BLL.BusinessProcesses.CaseProcesses;
using LegalexAccount.BLL.BusinessProcesses.ClientsProcesses;
using LegalexAccount.BLL.BusinessProcesses.SpecialistsProcesses;
using LegalexAccount.BLL.DTO;
using LegalexAccount.BLL.DTO.Case;
using LegalexAccount.DAL;
using LegalexAccount.Web.ViewModels;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;


namespace LegalexAccount.Web.Controllers
{
    [Authorize]
    public class CaseController : BaseController
    {
        private static CreateCaseViewModel? _caseViewModel = null;
        private readonly IUnitOfWork _unitOfWork;


        public CaseController(IUnitOfWork unitOfWork, IMediator mediator, IHttpContextAccessor httpContextAccessor)
            : base(mediator, httpContextAccessor)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<IActionResult> CaseCard(int id)
        {
            ViewData["ProfileModel"] = _profileModel;

            var result = (await _mediator.Send(new GetCasesRequest(id)))
                .FirstOrDefault()?.ToViewModel();

            return View(result);
        }

        [HttpGet]
        public async Task<IActionResult> CreateCase()
        {
            ViewBag.Clients = new List<SelectListItem>
            {
                new SelectListItem { Value = "", Text = "Выберите заказчика", Selected = true }
            }
            .Concat(
                (await _mediator.Send(new GetClientsQuery())).Select(x => new SelectListItem
                {
                    Value = x.Email ?? string.Empty,
                    Text = (x as LegalDTO)?.OrganizationName != null ? (x as LegalDTO)?.OrganizationName : x.FirstName + ' ' + x.LastName
                })).ToList();

            ViewBag.Assignees = (await _mediator.Send(new GetSpecialistsQuery()))
                .Select(x => new SelectListItem
                {
                    Value = x.Email ?? string.Empty,
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
        public async Task<IActionResult> SaveCase(CreateCaseViewModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            _caseViewModel = model;

            return Redirect("SaveCase");
        }

        [HttpGet]
        public async Task<IActionResult> SaveCase()
        {
            if (_caseViewModel == null)
                return BadRequest();

            try
            {
                await _mediator.Send(new CreateCaseCommand(await _caseViewModel.ToDTO(_unitOfWork)));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return RedirectToAction("Cases", "Home");
        }
    }
}
