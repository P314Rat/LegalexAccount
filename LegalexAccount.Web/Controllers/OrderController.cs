using LegalexAccount.BLL.BusinessProcesses.OrdersProcesses;
using LegalexAccount.Web.ViewModels;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace LegalexAccount.Web.Controllers
{
    [Authorize]
    public class OrderController : BaseController
    {
        public OrderController(IMediator mediator, IHttpContextAccessor httpContextAccessor)
            : base(mediator, httpContextAccessor) { }

        [HttpGet]
        public async Task<IActionResult> OrderCard(int id)
        {
            try
            {
                var orderDTO = (await _mediator.Send(new GetOrderByIdQuery(id)));
                var orderModel = orderDTO?.ToViewModel();

                ViewData["ProfileModel"] = _profileModel;

                return View(orderModel);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
