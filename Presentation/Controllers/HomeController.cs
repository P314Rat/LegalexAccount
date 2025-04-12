using Application.Core.BusinessLogic.AccountProcess.EditProfile;
using Application.Core.BusinessLogic.AccountProcess.GetClients;
using Application.Core.BusinessLogic.AccountProcess.GetSpecialists;
using Application.Core.BusinessLogic.CaseProcess.GetCase;
using Application.Core.BusinessLogic.OrderProcess.GetOrders;
using Application.Core.BusinessLogic.ProfileProcess.GetShortProfile;
using Application.Core.DTO;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Presentation.ViewModels;
using System.Security.Claims;
using Utilities.Types;


namespace Presentation.Controllers
{
    [Authorize]
    public class HomeController : BaseController
    {
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContextAccessor;


        public HomeController(IMediator mediator, IMapper mapper, IHttpContextAccessor httpContextAccessor)
            : base(mediator, httpContextAccessor)
        {
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
        }

        [Authorize(Roles = "Director, Technical, Specialist")]
        [HttpGet]
        public async Task<IActionResult> Orders(int currentPage = 1)
        {
            ViewData["ShortProfile"] = _shortProfileModel;

            const int ordersPerPage = 7;
            var skip = (currentPage - 1) * ordersPerPage;

            try
            {
                var tempResult = await _mediator.Send(new GetOrdersQuery(skip, ordersPerPage));
                var pagesNumber = (int)Math.Ceiling(tempResult.TotalCount / (double)ordersPerPage);
                var viewModels = tempResult.Items.Select(_mapper.Map<OrderViewModel>);
                var result = PagedResult<OrderViewModel>.Create(viewModels, tempResult.TotalCount, tempResult.PageSize, tempResult.CurrentPage);

                return View(result);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpGet]
        public async Task<IActionResult> Cases(int currentPage = 1)
        {
            ViewData["ShortProfile"] = _shortProfileModel;

            const int casesPerPage = 7;
            var skip = (currentPage - 1) * casesPerPage;
            var clientEmail = GetClientEmailIfApplicable();

            try
            {
                var query = new GetCasesQuery(skip, casesPerPage, clientEmail);
                var tempResult = await _mediator.Send(query);

                var testList = tempResult.Items;

                var viewModels = tempResult.Items.Select(_mapper.Map<CaseViewModel>);
                var pagedResult = PagedResult<CaseViewModel>.Create(
                    viewModels,
                    tempResult.TotalCount,
                    tempResult.PageSize,
                    tempResult.CurrentPage
                );

                return View(pagedResult);
            }
            catch
            {
                return BadRequest();
            }
        }

        [Authorize(Roles = "Director, Technical, Specialist")]
        [HttpGet]
        public async Task<IActionResult> Clients(int currentPage = 1)
        {
            ViewData["ShortProfile"] = _shortProfileModel;

            const int clientsPerPage = 7;
            var skip = (currentPage - 1) * clientsPerPage;

            try
            {
                var tempResult = await _mediator.Send(new GetClientsQuery(skip, clientsPerPage));
                var pagesNumber = (int)Math.Ceiling(tempResult.TotalCount / (double)clientsPerPage);
                var viewModels = tempResult.Items.Select(_mapper.Map<ClientViewModel>);
                var result = PagedResult<ClientViewModel>.Create(viewModels, tempResult.TotalCount, tempResult.PageSize, tempResult.CurrentPage);

                return View(result);
            }
            catch
            {
                return BadRequest();
            }
        }

        [Authorize(Roles = "Director, Technical, Specialist")]
        [HttpGet]
        public async Task<IActionResult> Specialists(int currentPage = 1)
        {
            ViewData["ShortProfile"] = _shortProfileModel;

            const int specialistsPerPage = 7;
            var skip = (currentPage - 1) * specialistsPerPage;

            try
            {
                var tempResult = await _mediator.Send(new GetSpecialistsQuery(skip, specialistsPerPage));
                var pagesNumber = (int)Math.Ceiling(tempResult.TotalCount / (double)specialistsPerPage);
                var viewModels = tempResult.Items.Select(_mapper.Map<SpecialistViewModel>);
                var result = PagedResult<SpecialistViewModel>.Create(viewModels, tempResult.TotalCount, tempResult.PageSize, tempResult.CurrentPage);

                return View(result);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpGet]
        public async Task<IActionResult> Calendar()
        {
            ViewData["ShortProfile"] = _shortProfileModel;

            return View();
        }

        [HttpGet]
        public async Task<IActionResult> EditProfile()
        {
            ViewData["ShortProfile"] = _shortProfileModel;

            try
            {
                var profile = await _mediator.Send(new GetShortProfileQuery(_shortProfileModel.Email));
                var result = _mapper.Map<EditProfileViewModel>(profile);

                return View(result);
            }
            catch
            {
                return View();
            }
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> EditProfile(EditProfileViewModel model)
        {
            ViewData["ShortProfile"] = _shortProfileModel;

            if (!ModelState.IsValid)
                return View("EditProfile", model);

            try
            {
                await _mediator.Send(new EditProfileCommand(_mapper.Map<ProfileDTO>(model)));
            }
            catch
            {
                return View("EditProfile", model);
            }

            return Redirect("EditProfile");
        }

        private string? GetClientEmailIfApplicable()
        {
            var user = _httpContextAccessor?.HttpContext?.User;
            var role = user?.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role)?.Value;

            if (role == UserRole.Client.ToString())
            {
                return user?.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Name)?.Value;
            }

            return null;
        }
    }
}
