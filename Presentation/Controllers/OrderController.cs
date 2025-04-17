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
        private readonly IMediator _mediator;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IMapper _mapper;


        public OrderController(IMediator mediator, IHttpContextAccessor httpContextAccessor, IMapper mapper) : base(mediator, httpContextAccessor)
        {
            _mediator = mediator;
            _httpContextAccessor = httpContextAccessor;
            _mapper = mapper;
        }

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
    }
}
