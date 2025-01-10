using LegalexAccount.BLL.BusinessProcesses.OrdersProcesses;
using LegalexAccount.DAL;
using LegalexAccount.Web.ViewModels;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace LegalexAccount.Web.Controllers
{
    [Authorize]
    public class OrderController : BaseController
    {
        private readonly IMediator _mediator;


        public OrderController(IMediator mediator, IApplicationDbContextFactory _dbContextFactory, IHttpContextAccessor httpContextAccessor)
            : base(_dbContextFactory, httpContextAccessor)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> OrderCard(int id)
        {
            try
            {
                var orderDTO = (await _mediator.Send(new GetOrdersQuery(id))).FirstOrDefault();
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
