using Application.Core.BusinessLogic.AccountProcess.EditProfile;
using Application.Core.BusinessLogic.OrderProcess.GetOrders;
using Application.Core.BusinessLogic.ProfileProcess.GetShortProfile;
using Application.Core.DTO;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Presentation.ViewModels;


namespace Presentation.Controllers
{
    [Authorize]
    public class HomeController : BaseController
    {
        private readonly IMapper _mapper;

        public HomeController(IMediator mediator, IMapper mapper, IHttpContextAccessor httpContextAccessor)
            : base(mediator, httpContextAccessor)
        {
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Orders(int currentPage = 1)
        {
            ViewData["ShortProfile"] = _shortProfileModel;
            ViewData["CurrentPage"] = currentPage;

            try
            {
                var ordersModel = (await _mediator.Send(new GetOrdersQuery())).Select(_mapper.Map<OrderViewModel>).ToList();

                return View(ordersModel);
            }
            catch
            {
                return View(new List<OrderViewModel>());
            }
        }

        //[HttpGet]
        //public async Task<IActionResult> Cases(int currentPage = 1)
        //{
        //    ViewData["ProfileModel"] = _shortProfileModel; //Vanya
        //    ViewData["CurrentPage"] = currentPage;

        //    var cases = (await _mediator.Send(new GetCasesRequest()))
        //        .Select(x => x.ToViewModel())
        //        .ToList();

        //    return View(cases);
        //}

        //[HttpGet]
        //public async Task<IActionResult> Clients(int currentPage = 1)
        //{
        //    ViewData["ShortProfile"] = _shortProfileModel;
        //    ViewData["CurrentPage"] = currentPage;

        //    var clients = (await _mediator.Send(new GetClientsQuery()))
        //        .Select(x => _mapper.Map<ClientProfileViewModel>(x))
        //        .ToList();

        //    return View(clients);
        //}

        //[HttpGet]
        //public IActionResult Calendar()
        //{
        //    ViewData["ProfileModel"] = _shortProfileModel;

        //    return View();
        //}

        //[Authorize(Roles = "Director, Technical, Specialist")]
        //[HttpGet]
        //public async Task<IActionResult> Employees()
        //{
        //    var response = (await _mediator.Send(new GetSpecialistsQuery()))
        //        ?.Where(x => x.Email != _shortProfileModel?.Email)
        //        .ToList();

        //    ViewData["ProfileModel"] = _shortProfileModel;

        //    return View(response);
        //}

        //[HttpGet]
        //public IActionResult Chats(string? email)
        //{
        //    ViewData["ProfileModel"] = _shortProfileModel;

        //    return View(new ChatViewModel());
        //}

        [Authorize]
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
    }
}
