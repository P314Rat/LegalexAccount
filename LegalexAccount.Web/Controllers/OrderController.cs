using LegalexAccount.BLL.BusinessProcesses.Identification;
using LegalexAccount.BLL.BusinessProcesses.OrdersProcesses;
using LegalexAccount.BLL.DTO;
using LegalexAccount.Web.ViewModels;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;


namespace LegalexAccount.Web.Controllers
{
    [Authorize]
    public class OrderController : Controller
    {
        private readonly IMediator _mediator;
        private static ProfileViewModel _userModel;


        public OrderController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> OrderCard(int id)
        {
            var email = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Name)?.Value;

            if (email == null)
                return BadRequest();

            _userModel = (await _mediator.Send(new IdentificationQuery(email))).ToViewModel();

            OrderDTO? orderDTO;

            try
            {
                orderDTO = (await _mediator.Send(new GetOrdersQuery(id))).FirstOrDefault();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            var orderModel = orderDTO?.ToViewModel();

            ViewData["UserViewModel"] = _userModel;

            return View(orderModel);
        }
    }
}
