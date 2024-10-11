using LegalexAccount.DAL.Models;
using LegalexAccount.DAL.Models.OrderAggregate;
using LegalexAccount.Web.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Security.Claims;


namespace LegalexAccount.Web.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private static UserViewModel _userModel;


        public HomeController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public IActionResult Orders(int currentPage = 1)
        {
            var email = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Name)?.Value;

            if (email == null)
                return BadRequest();

            var user = _unitOfWork.Users.GetByEmail(email);
            _userModel = new UserViewModel
            {
                Email = user.Email ?? string.Empty,
                FirstName = user.FirstName,
                LastName = user.LastName
            };
            var orders = _unitOfWork.Orders.GetAll();
            var ordersModel = (from order in orders
                               select new OrderViewModel
                               {
                                   Id = order.Id,
                                   CreatedAt = order.CreatedAt,
                                   ClientType = order.ClientType,
                                   Contact = order.Contact,
                                   Name = order.Name,
                                   Service = order.Service,
                                   Description = order.Description
                               }).ToList();

            ViewData["UserViewModel"] = _userModel;
            ViewData["CurrentPage"] = currentPage;

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
            var specialists = _unitOfWork.Specialists.GetAll()?.Where(x => x.Email != _userModel.Email);
            var specialistsModel = (from specialist in specialists
                                    select new SpecialistViewModel
                                    {
                                        Status = specialist.Status,
                                        Role = specialist.Role,
                                        Email = specialist.Email ?? string.Empty,
                                        FirstName = specialist.FirstName,
                                        LastName = specialist.LastName,
                                    }).ToList();

            ViewData["UserViewModel"] = _userModel;

            return View(specialistsModel);
        }
    }
}
