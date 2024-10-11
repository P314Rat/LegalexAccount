using LegalexAccount.DAL.Models;
using LegalexAccount.DAL.Models.OrderAggregate;
using LegalexAccount.Web.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;


namespace LegalexAccount.Web.Controllers
{
    [Authorize]
    public class OrderController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private static UserViewModel _userModel;


        public OrderController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public IActionResult OrderCard(int id)
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

            Order order;

            try
            {
                order = _unitOfWork.Orders.GetById(id);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            var orderModel = new OrderViewModel
            {
                Id = id,
                CreatedAt = order.CreatedAt,
                ClientType = order.ClientType,
                Contact = order.Contact,
                Name = order.Name,
                Service = order.Service,
                Description = order.Description
            };

            ViewData["UserViewModel"] = _userModel;

            return View(orderModel);
        }
    }
}
