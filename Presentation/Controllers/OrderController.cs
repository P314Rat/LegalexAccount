using Application.Core.BusinessLogic.OrderProcess.DeleteProcess;
using Application.Core.BusinessLogic.OrderProcess.GetOrders;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Presentation.ViewModels;


namespace Presentation.Controllers
{
    [Authorize]
    public class OrderController : BaseController
    {
        private readonly IMapper _mapper;


        public OrderController(IMediator mediator, IHttpContextAccessor httpContextAccessor, IMapper mapper) : base(mediator, httpContextAccessor)
        {
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> OrderCard(int id)
        {
            ViewData["ShortProfile"] = _shortProfileModel;

            try
            {
                var tempResult = await _mediator.Send(new GetOrderByIdQuery(id));
                var result = _mapper.Map<OrderViewModel>(tempResult);

                return View(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            await _mediator.Send(new DeleteOrderCommand(id));

            return RedirectToAction("Orders", "Home");
        }
    }
}
