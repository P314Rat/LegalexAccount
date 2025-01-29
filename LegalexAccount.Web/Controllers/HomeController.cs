using LegalexAccount.BLL.BusinessProcesses.CaseProcesses;
using LegalexAccount.BLL.BusinessProcesses.ClientsProcesses;
using LegalexAccount.BLL.BusinessProcesses.SpecialistsProcesses;
using LegalexAccount.BLL.BusinessProcesses.OrdersProcesses;
using LegalexAccount.BLL.DTO;
using LegalexAccount.Web.ViewModels;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using LegalexAccount.BLL.BusinessProcesses.ProfileProcesses;


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

            var cases = (await _mediator.Send(new GetCasesRequest())).Select(x => x.ToViewModel()).ToList();

            return View(cases);
        }

        [HttpGet]
        public async Task<IActionResult> Clients(int currentPage = 1)
        {
            ViewData["ProfileModel"] = _profileModel;
            ViewData["CurrentPage"] = currentPage;

            try
            {
                var legals = new List<LegalViewModel>();
                var individuals = new List<PersonViewModel>();
                var clients = (await _mediator.Send(new GetClientsQuery())).Select(user =>
                {
                    var organizationName = user is LegalDTO ? ((LegalDTO)user).OrganizationName : null;

                    return new ProfileDTO
                    {
                        Email = user.Email ?? string.Empty,
                        FirstName = user.FirstName ?? string.Empty,
                        LastName = user.LastName ?? string.Empty,
                    };
                }).Select(x => x.ToViewModel()).ToList();

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

        [Authorize(Roles = "Director, Technical, Employee")]
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
        public async Task<IActionResult> EditProfile()
        {
            ViewData["ProfileModel"] = _profileModel;

            return View();
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> EditProfile(UserViewModel model)
        {
            var editableModel = new UserDTO
            {
                FirstName = _profileModel.FirstName,
                LastName = _profileModel.LastName,
                SurName = _profileModel.SurName,
                Email = _profileModel.Email,
                PhoneNumber = _profileModel.PhoneNumber
            };

            await _mediator.Send(new EditProfileCommand(editableModel, model.ToDTO()));

            if(model.Email != _profileModel.Email)
                return RedirectToAction("Logout", "Account");

            ViewData["ProfileModel"] = _profileModel;

            return View();
        }
    }
}
