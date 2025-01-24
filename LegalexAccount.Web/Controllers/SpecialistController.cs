using LegalexAccount.BLL.BusinessProcesses.SpecialistsProcesses;
using LegalexAccount.Utility.Extensions;
using LegalexAccount.Utility.Types;
using LegalexAccount.Web.ViewModels;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;


namespace LegalexAccount.Web.Controllers
{
    [Authorize(Roles = "Director, Technical, Employee")]
    public class SpecialistController : BaseController
    {
        private static UserViewModel? _userModel = null;
        private static SpecialistViewModel? _specialistModel = null;


        public SpecialistController(IMediator mediator, IHttpContextAccessor httpContextAccessor)
            : base(mediator, httpContextAccessor) { }

        [HttpGet]
        public async Task<IActionResult> EmployeeCard(string email)
        {
            try
            {
                var response = (await _mediator.Send(new GetSpecialistByEmailQuery(email)))?.ToViewModel();

                if (response == null)
                    throw new Exception("Specialist not found");

                ViewData["ProfileModel"] = _profileModel;

                return View(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Authorize(Roles = "Director")]
        [HttpGet]
        public IActionResult CreateEmployee(int stepNumber = 1)
        {
            try
            {
                ViewData["ProfileModel"] = _profileModel;

                if (stepNumber == 2)
                {
                    ViewBag.Roles = new List<SelectListItem>
                    {
                        new SelectListItem { Value = "", Text = "Выберите роль специалиста", Selected = true }
                    }
                    .Concat(
                        Enum.GetValues(typeof(SpecialistRole))
                        .Cast<SpecialistRole>()
                        .Where(x => x != SpecialistRole.Director)
                        .Select(x => new SelectListItem
                        {
                            Value = x.ToString(),
                            Text = x.GetDisplayName()
                        })
                        .ToList());
                }

                return View(stepNumber);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Authorize(Roles = "Director")]
        [HttpPost]
        public IActionResult CreateStepOne(UserViewModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest("Wrong model");

            const int stepNumber = 2;
            _userModel = model;

            return RedirectToAction("CreateEmployee", new { stepNumber });
        }

        [Authorize(Roles = "Director")]
        [HttpPost]
        public async Task<IActionResult> SaveEmployee(SpecialistViewModel model)
        {
            _specialistModel = model;

            if (_userModel != null)
            {
                _specialistModel.Email = _userModel.Email;
                _specialistModel.Phone = _userModel.Phone;
                _specialistModel.FirstName = _userModel.FirstName;
                _specialistModel.LastName = _userModel.LastName;
                _specialistModel.SurName = _userModel.SurName;
                _specialistModel.Password = _userModel.Password;

                await _mediator.Send(new CreateEmployeeQuery(_specialistModel.ToDTO())); // Create new

                _userModel = null;
                _specialistModel = null;
            }
            else
            {
                var mailRequest = new MailRequest
                {
                    ToEmail = "silencetray@gmail.com",
                    Subject = "Подтверждение аккаунта",
                    Body = "Test"
                };

                await _mediator.Send(new EditEmployeeQuery(_specialistModel.ToDTO(), mailRequest)); // Edit existing

                _specialistModel = null;
            }

            return RedirectToAction("Employees", "Home");
        }
    }
}
