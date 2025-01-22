using LegalexAccount.BLL.BusinessProcesses.CaseProcesses;
using LegalexAccount.BLL.BusinessProcesses.ClientsProcesses;
using LegalexAccount.BLL.BusinessProcesses.EmployeesProcesses;
using LegalexAccount.BLL.BusinessProcesses.OrdersProcesses;
using LegalexAccount.BLL.DTO;
using LegalexAccount.DAL;
using LegalexAccount.Utility.Types;
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
        private readonly IMediator _mediator;


        public HomeController(IMediator mediator, IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor)
            : base(unitOfWork, httpContextAccessor)
        {
            _mediator = mediator;
        }

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

        [HttpGet]
        public async Task<IActionResult> Employees()
        {
            try
            {
                var result = (await _mediator.Send(new GetEmployeesQuery()))
                    .Where(x => x.Email != _profileModel?.Email)
                    .Select(x => x.ToViewModel())
                    .ToList();

                ViewData["ProfileModel"] = _profileModel; //Создать общую ViewModel

                return View(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
