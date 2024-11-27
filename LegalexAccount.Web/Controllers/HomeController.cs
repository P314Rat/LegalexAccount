using LegalexAccount.BLL.BusinessProcesses.ClientsProcesses;
using LegalexAccount.BLL.BusinessProcesses.EmployeesProcesses;
using LegalexAccount.BLL.BusinessProcesses.OrdersProcesses;
using LegalexAccount.BLL.DTO;
using LegalexAccount.DAL.Models;
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


        public HomeController(IMediator mediator, IApplicationDbContextFactory _dbContextFactory, IHttpContextAccessor httpContextAccessor)
            : base(_dbContextFactory, httpContextAccessor)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Orders(int currentPage = 1)
        {
            ViewData["ProfileModel"] = _profileModel;

            try
            {
                var ordersModel = (await _mediator.Send(new GetOrdersQuery())).Select(x => x.ToViewModel()).ToList();
                ViewData["CurrentPage"] = currentPage;

                return View(ordersModel);
            }
            catch
            {
                return View(new List<OrderViewModel>());
            }
        }

        [HttpGet]
        public IActionResult Cases()
        {
            ViewData["ProfileModel"] = _profileModel;

            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Clients(int currentPage = 1)
        {
            ViewData["ProfileModel"] = _profileModel;

            try
            {
                var clients = (await _mediator.Send(new GetClientsQuery())).Select(user =>
                {
                    UserType userType = user switch
                    {
                        LegalDTO => UserType.Legal,
                        PersonDTO => UserType.Person,
                        _ => throw new Exception($"Unknown UserDTO type: {user.GetType()}")
                    };

                    return new ProfileDTO
                    {
                        Email = user.Email ?? string.Empty,
                        FirstName = user.FirstName ?? string.Empty,
                        LastName = user.LastName ?? string.Empty,
                        UserType = userType
                    };
                }).Select(x => x.ToViewModel()).ToList();

                ViewData["CurrentPage"] = currentPage;

                return View(clients);
            }
            catch
            {
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
                if (_profileModel == null)
                    return BadRequest("Authorization is wrong.");

                var specialists = await _mediator.Send(new GetEmployeesQuery(_profileModel.Email));
                var specialistsModel = specialists.Select(x => x.ToViewModel()).ToList();
                ViewData["ProfileModel"] = _profileModel;

                return View(specialistsModel);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
