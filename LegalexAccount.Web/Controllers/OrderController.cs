﻿using LegalexAccount.BLL.BusinessProcesses.Identification;
using LegalexAccount.BLL.BusinessProcesses.OrdersProcesses;
using LegalexAccount.DAL.Models;
using LegalexAccount.Web.ViewModels;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;


namespace LegalexAccount.Web.Controllers
{
    [Authorize]
    public class OrderController : BaseController
    {
        private readonly IMediator _mediator;
        private static ProfileViewModel? _userModel = null;


        public OrderController(IMediator mediator, IApplicationDbContextFactory _dbContextFactory, IHttpContextAccessor httpContextAccessor)
            : base(_dbContextFactory, httpContextAccessor)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> OrderCard(int id)
        {
            var email = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Name)?.Value;

            if (email == null)
                return BadRequest("Authorization is wrong.");

            try
            {
                var orderDTO = (await _mediator.Send(new GetOrdersQuery(id))).FirstOrDefault();
                var orderModel = orderDTO?.ToViewModel();

                _userModel = (await _mediator.Send(new IdentificationQuery(email))).ToViewModel();
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
