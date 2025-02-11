using LegalexAccount.BLL.BusinessProcesses.ProfileProcesses;
using LegalexAccount.Web.ViewModels;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;


namespace LegalexAccount.Web.Controllers
{
    public class BaseController : Controller
    {
        protected static ShortProfileViewModel _profileModel = new();
        protected readonly IMediator _mediator;


        public BaseController(IMediator mediator, IHttpContextAccessor httpContextAccessor)
        {
            _mediator = mediator;
            var email = httpContextAccessor.HttpContext?.User?.Claims
                .FirstOrDefault(c => c.Type == ClaimTypes.Name)?.Value;

            if (email == null)
                throw new Exception("Authorization is wrong.");

            var shortProfileDTO = _mediator.Send(new GetShortProfileQuery(email)).Result;

            if (shortProfileDTO == null)
                throw new Exception("Authorization is wrong.");

            _profileModel.FirstName = shortProfileDTO.FirstName ?? string.Empty;
            _profileModel.LastName = shortProfileDTO.LastName ?? string.Empty;
            _profileModel.Email = email;
        }
    }
}
