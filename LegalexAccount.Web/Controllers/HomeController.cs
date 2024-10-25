using LegalexAccount.BLL.BusinessProcesses.EmployeesProcesses;
using LegalexAccount.BLL.BusinessProcesses.Identification;
using LegalexAccount.BLL.BusinessProcesses.OrdersProcesses;
using LegalexAccount.Web.ViewModels;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Security.Claims;


namespace LegalexAccount.Web.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly IMediator _mediator;
        private static ProfileViewModel? _userModel = null;


        public HomeController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Orders(int currentPage = 1)
        {
            var email = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Name)?.Value;

            if (email == null)
                return BadRequest("Authorization is wrong.");

            try
            {
                List<OrderViewModel> ordersModel;
                ordersModel = (await _mediator.Send(new GetOrdersQuery())).Select(x => x.ToViewModel()).ToList();

                _userModel = (await _mediator.Send(new IdentificationQuery(email))).ToViewModel();
                ViewData["UserViewModel"] = _userModel;
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
            ViewData["UserViewModel"] = _userModel;

            return View();
        }

        [HttpGet]
        public IActionResult Clients()
        {
            ViewData["UserViewModel"] = _userModel;

            return View();
        }

        [HttpGet]
        public IActionResult Calendar()
        {
            ViewData["UserViewModel"] = _userModel;

            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Employees()
        {
            try
            {
                if (_userModel == null)
                    return BadRequest("Authorization is wrong.");

                var specialists = await _mediator.Send(new GetEmployeesQuery(_userModel.Email));
                var specialistsModel = specialists.Select(x => x.ToViewModel()).ToList();
                ViewData["UserViewModel"] = _userModel;

                return View(specialistsModel);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
