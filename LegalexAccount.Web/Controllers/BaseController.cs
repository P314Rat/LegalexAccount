using LegalexAccount.BLL.BusinessProcesses.ProfileProcesses;
using LegalexAccount.BLL.DTO;
using LegalexAccount.Web.ViewModels;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;


namespace LegalexAccount.Web.Controllers
{
    public class BaseController : Controller
    {
        protected static readonly ShortProfileViewModel _profileModel;
        protected readonly IMediator _mediator;


        static ShortProfileViewModel()
        {
            _profileModel = LoadProfile();
        }

        private static ShortProfileViewModel LoadProfile()
        {
            var profileDTO = _mediator.Send(new GetProfileQuery(email)).Result;

            return new ShortProfileViewModel
            {
                FirstName = profileDTO.FirstName,
                LastName = profileDTO.LastName,
                SurName = profileDTO.SurName,
                Email = email,
                PhoneNumber = profileDTO.PhoneNumber
            };
        }

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
