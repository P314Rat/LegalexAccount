using LegalexAccount.DAL.Models;
using LegalexAccount.Web.ViewModels;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace LegalexAccount.Web.Controllers
{
    [Authorize]
    public class ClientController : BaseController
    {
        private readonly IMediator _mediator;
        private static UserViewModel? _userModel = null;
        private static LegalViewModel? _legalModel = null;
        private static PersonViewModel? _personModel = null;


        public ClientController(IMediator mediator, IApplicationDbContextFactory _dbContextFactory, IHttpContextAccessor httpContextAccessor)
            : base(_dbContextFactory, httpContextAccessor)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> CreateClient()
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

        [HttpGet]
        public async Task<IActionResult> StepTwo(bool isLegal = true)
        {
            try
            {
                const int stepNumber = 2;

                if (_profileModel == null)
                    return BadRequest("Authorization is wrong.");

                ViewData["ProfileModel"] = _profileModel;
                ViewData["IsLegalProfile"] = isLegal;

                return View("CreateClient", stepNumber);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public async Task<IActionResult> StepThree(bool isCreateFormActive = false)
        {
            try
            {
                const int stepNumber = 3;

                ViewData["IsCreateFormActive"] = isCreateFormActive;
                ViewData["ProfileModel"] = _profileModel;

                return View("CreateClient", stepNumber);
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
                ViewData["ProfileModel"] = _profileModel;

                return View("CreateClient", stepNumber);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> LegalCreate(LegalViewModel model)
        {
            _legalModel = model;
            _legalModel.Email = _userModel.Email;
            _legalModel.Phone = _userModel.Phone;
            _legalModel.FirstName = _userModel.FirstName;
            _legalModel.LastName = _userModel.LastName;
            _legalModel.SurName = _userModel.SurName;
            _legalModel.Password = _userModel.Password;

            return Redirect("StepThree");
        }

        [HttpGet]
        public async Task<IActionResult> SaveClient()
        {
            return RedirectToAction("Clients", "Home");
        }

        [HttpPost]
        public async Task<IActionResult> SaveClient(CaseViewModel? model)
        {
            return RedirectToAction("Home", "Clients");
        }
    }
}
