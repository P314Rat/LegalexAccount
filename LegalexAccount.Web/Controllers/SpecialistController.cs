using LegalexAccount.BLL.BusinessProcesses.EmployeesProcesses;
using LegalexAccount.DAL;
using LegalexAccount.Utility.Extensions;
using LegalexAccount.Utility.Types;
using LegalexAccount.Web.ViewModels;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;


namespace LegalexAccount.Web.Controllers
{
    public class SpecialistController : BaseController
    {
        private readonly IMediator _mediator;
        private static UserViewModel? _userModel = null;
        private static SpecialistViewModel? _specialistModel = null;


        public SpecialistController(IMediator mediator, IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor)
            : base(unitOfWork, httpContextAccessor)
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

        [HttpGet]
        public async Task<IActionResult> CreateEmployee()
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
        public async Task<IActionResult> StepTwo(UserViewModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest("Wrong model");

            try
            {
                const int stepNumber = 2;

                if (_profileModel == null)
                    return BadRequest("Authorization is wrong.");

                _userModel = model;

                return Redirect("StepTwo");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public async Task<IActionResult> StepTwo()
        {
            try
            {
                const int stepNumber = 2;

                if (_profileModel == null)
                    return BadRequest("Authorization is wrong.");

                ViewData["ProfileModel"] = _profileModel;
                ViewBag.Statuses = Enum.GetValues(typeof(SpecialistStatus))
                    .Cast<SpecialistStatus>()
                    .Select(x => new SelectListItem
                    {
                        Value = x.ToString(),
                        Text = x.GetDisplayName()
                    })
                    .ToList();
                ViewBag.Roles = new List<SelectListItem>
                {
                    new SelectListItem { Value = "", Text = "Выберите роль специалиста", Selected = true }
                }
                .Concat(
                    Enum.GetValues(typeof(SpecialistRole))
                    .Cast<SpecialistRole>()
                    .Select(x => new SelectListItem
                    {
                        Value = x.ToString(),
                        Text = x.GetDisplayName()
                    })
                    .ToList());

                return View("CreateEmployee", stepNumber);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> SaveEmployee(SpecialistViewModel model)
        {
            _specialistModel = model;
            _specialistModel.Email = _userModel.Email;
            _specialistModel.Phone = _userModel.Phone;
            _specialistModel.FirstName = _userModel.FirstName;
            _specialistModel.LastName = _userModel.LastName;
            _specialistModel.SurName = _userModel.SurName;
            _specialistModel.Password = _userModel.Password;
            //Добавить перегрузку для преобразования ViewModel

            await _mediator.Send(new CreateEmployeeQuery(_specialistModel.ToDTO()));

            return Ok();
        }
    }
}
