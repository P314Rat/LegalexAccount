using LegalexAccount.BLL.BusinessProcesses.ProfileProcesses;
using LegalexAccount.Web.ViewModels;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;


namespace LegalexAccount.Web.Controllers
{
    public class BaseController : Controller
    {
        protected static ProfileViewModel? _profileModel = null;
        protected readonly IMediator _mediator;


        public BaseController(IMediator mediator, IHttpContextAccessor httpContextAccessor)
        {
            _mediator = mediator;

            var email = httpContextAccessor.HttpContext?.User?.Claims
                .FirstOrDefault(c => c.Type == ClaimTypes.Name)?.Value;

            if (email == null)
                throw new Exception("Authorization is wrong.");

            var profileDTO = _mediator.Send(new GetProfileQuery(email)).Result;

            if (profileDTO != null)
            {
                _profileModel = new()
                {
                    FirstName = profileDTO.FirstName,
                    LastName = profileDTO.LastName,
                    SurName = profileDTO.SurName,
                    Email = email,
                    PhoneNumber = profileDTO.PhoneNumber
                };
            }
            else
            {
                throw new Exception("Authorization is wrong.");
            }
        }
    }
}
