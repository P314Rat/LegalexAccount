using Application.Core.BusinessLogic.ClientProcess.GetClients;
using Application.Core.BusinessLogic.SpecialistProcess.GetSpecialists;
using Application.Core.DTO;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Presentation.ViewModels;
using System.Data;


namespace Presentation.Controllers
{
    [Authorize]
    public class HomeController : BaseController
    {
        private readonly IMapper _mapper;
        //private readonly PresenceTrackerService _presence;

        public HomeController(IMediator mediator, IMapper mapper, IHttpContextAccessor httpContextAccessor)
            : base(mediator, httpContextAccessor)
        {
            _mapper = mapper;
            //_presence = presence;
        }

        //[HttpGet]
        //public async Task<IActionResult> Orders(int currentPage = 1)
        //{
        //    ViewData["ProfileModel"] = _shortProfileModel;
        //    ViewData["CurrentPage"] = currentPage;

        //    try
        //    {
        //        var ordersModel = (await _mediator.Send(new GetOrdersQuery())).Select(x => x.ToViewModel()).ToList();

        //        return View(ordersModel);
        //    }
        //    catch
        //    {
        //        return View(new List<OrderViewModel>());
        //    }
        //}

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

        [HttpGet]
        public async Task<IActionResult> Clients(int currentPage = 1)
        {
            ViewData["ShortProfile"] = _shortProfileModel;
            ViewData["CurrentPage"] = currentPage;

            var clients = (await _mediator.Send(new GetClientsQuery()))
                .Select(x => _mapper.Map<ClientProfileViewModel>(x))
                .ToList();

            return View(clients);
        }

        //[HttpGet]
        //public IActionResult Calendar()
        //{
        //    ViewData["ProfileModel"] = _shortProfileModel;

        //    return View();
        //}

        [Authorize(Roles = "Director, Technical, Specialist")]
        [HttpGet]
        public async Task<IActionResult> Employees()
        {
            var response = (await _mediator.Send(new GetSpecialistsQuery()))
                ?.Where(x => x.Email != _shortProfileModel?.Email)
                .ToList();

            ViewData["ProfileModel"] = _shortProfileModel;

            return View(response);
        }

        //[HttpGet]
        //public IActionResult Chats(string? email)
        //{
        //    ViewData["ProfileModel"] = _shortProfileModel;

        //    return View(new ChatViewModel());
        //}

        [Authorize]
        [HttpGet]
        public IActionResult EditProfile()
        {
            ViewData["ProfileModel"] = _shortProfileModel;
            ViewData["PaswordWasChanged"] = false;

            return View();
        }

        //[Authorize]
        //[HttpPost]
        //public async Task<IActionResult> EditProfile(ProfileViewModel model)
        //{
        //    ViewData["ProfileModel"] = _shortProfileModel;
        //    ViewData["PaswordWasChanged"] = false;

        //    if (!ModelState.IsValid)
        //    {
        //        ViewData["PaswordWasChanged"] = true;

        //        return View("EditProfile", model);
        //    }

        //    try
        //    {
        //        await _mediator.Send(new EditProfileCommand(_shortProfileModel.Email, model.ToDTO()));
        //    }
        //    catch (Utility.Exceptions.ValidationException ex)
        //    {
        //        ViewData["PaswordWasChanged"] = true;
        //        ModelState.AddModelError(ex.WrongFieldName, ex.Message);

        //        return View("EditProfile", model);
        //    }

        //    if (model.Email != _shortProfileModel.Email || model.NewPassword != null)
        //        return RedirectToAction("Logout", "Account");

        //    return Redirect("EditProfile");
        //}
    }
}
