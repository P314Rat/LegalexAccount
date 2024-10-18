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
        private static ProfileViewModel? _userModel;


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

            _userModel = (await _mediator.Send(new IdentificationQuery(email))).ToViewModel();
            ViewData["UserViewModel"] = _userModel;
            ViewData["CurrentPage"] = currentPage;

            List<OrderViewModel> ordersModel;

            try
            {
                ordersModel = (await _mediator.Send(new GetOrdersQuery())).Select(x => x.ToViewModel()).ToList();
            }
            catch
            {
                return View(new List<OrderViewModel>());
            }

            return View(ordersModel);
        }

        [HttpGet]
        public IActionResult Cases()
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
        public IActionResult Employees()
        {
            //var specialists = _unitOfWork.Specialists.GetAll()?.Where(x => x.Email != _userModel.Email);
            //var specialistsModel = (from specialist in specialists
            //                        select new SpecialistViewModel
            //                        {
            //                            Status = specialist.Status,
            //                            Role = specialist.Role,
            //                            Email = specialist.Email ?? string.Empty,
            //                            FirstName = specialist.FirstName,
            //                            LastName = specialist.LastName,
            //                        }).ToList();

            ViewData["UserViewModel"] = _userModel;

            return View(new List<SpecialistViewModel>());
        }
    }
}
