using LegalexAccount.BLL.BusinessProcesses.CaseProcesses;
using LegalexAccount.BLL.BusinessProcesses.ClientsProcesses;
using LegalexAccount.BLL.BusinessProcesses.OrdersProcesses;
using LegalexAccount.BLL.BusinessProcesses.ProfileProcesses;
using LegalexAccount.BLL.BusinessProcesses.SpecialistsProcesses;
using LegalexAccount.BLL.DTO;
using LegalexAccount.Web.ViewModels;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;


namespace LegalexAccount.Web.Controllers
{
    [Authorize]
    public class HomeController : BaseController
    {
        public HomeController(IMediator mediator, IHttpContextAccessor httpContextAccessor)
            : base(mediator, httpContextAccessor) { }

        [HttpGet]
        public async Task<IActionResult> Orders(int currentPage = 1)
        {
            ViewData["ProfileModel"] = _profileModel;
            ViewData["CurrentPage"] = currentPage;

            try
            {
                var ordersModel = (await _mediator.Send(new GetOrdersQuery())).Select(x => x.ToViewModel()).ToList();

                return View(ordersModel);
            }
            catch
            {
                return View(new List<OrderViewModel>());
            }
        }

        [HttpGet]
        public async Task<IActionResult> Cases(int currentPage = 1)
        {
            ViewData["ProfileModel"] = _profileModel; //Vanya
            ViewData["CurrentPage"] = currentPage;

            var cases = (await _mediator.Send(new GetCasesRequest()))
                .Select(x => x.ToViewModel())
                .ToList();

            return View(cases);
        }

        [HttpGet]
        public async Task<IActionResult> Clients(int currentPage = 1)
        {
            ViewData["ProfileModel"] = _profileModel;
            ViewData["CurrentPage"] = currentPage;

            try
            {
                var clients = (await _mediator.Send(new GetClientsQuery()))
                    .Select(x => x is LegalDTO
                        ? (UserViewModel)(x as LegalDTO).ToViewModel()
                        : (x as PersonDTO).ToViewModel())
                    .ToList();

                return View(clients);
            }
            catch (Exception ex)
            {
                //Лог
                return View(new List<ProfileViewModel>());
            }
        }

        [HttpGet]
        public IActionResult Calendar()
        {
            ViewData["ProfileModel"] = _profileModel;

            return View();
        }

        [Authorize(Roles = "Director, Technical, Specialist")]
        [HttpGet]
        public async Task<IActionResult> Employees()
        {
            try
            {
                var response = (await _mediator.Send(new GetSpecialistsQuery()))
                    .Where(x => x.Email != _profileModel?.Email)
                    .Select(x => x.ToViewModel())
                    .ToList();

                ViewData["ProfileModel"] = _profileModel;

                return View(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Authorize]
        [HttpGet]
        public IActionResult EditProfile()
        {
            ViewData["ProfileModel"] = _profileModel;
            ViewData["PaswordWasChanged"] = false;

            return View();
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> EditProfile(ProfileViewModel model)
        {
            ViewData["ProfileModel"] = _profileModel;
            ViewData["PaswordWasChanged"] = false;

            if (!ModelState.IsValid)
            {
                ViewData["PaswordWasChanged"] = true;

                return View("EditProfile", model);
            }

            try
            {
                await _mediator.Send(new EditProfileCommand(_profileModel.Email, model.ToDTO()));
            }
            catch (Utility.Exceptions.ValidationException ex)
            {
                ViewData["PaswordWasChanged"] = true;
                ModelState.AddModelError(ex.WrongFieldName, ex.Message);

                return View("EditProfile", model);
            }

            if (model.Email != _profileModel.Email || model.NewPassword != null)
                return RedirectToAction("Logout", "Account");

            return Redirect("EditProfile");
        }
    }
}
