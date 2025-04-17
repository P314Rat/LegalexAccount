using Application.Core.BusinessLogic.ProfileProcess.GetShortProfile;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Presentation.ViewModels;
using System.Security.Claims;


namespace Presentation.Controllers
{
    public class BaseController : Controller
    {
        protected static ShortProfileViewModel _shortProfileModel;
        protected readonly IMediator _mediator;


        static BaseController()
        {
            _shortProfileModel = new();
        }

        public BaseController(IMediator mediator, IHttpContextAccessor httpContextAccessor)
        {
            _mediator = mediator;

            try
            {
                var email = httpContextAccessor.HttpContext?.User?.Claims
                .FirstOrDefault(c => c.Type == ClaimTypes.Name)?.Value;

                if (email == null)
                    throw new Exception("Authorization is wrong.");

                var shortProfileDTO = _mediator.Send(new GetShortProfileQuery(email)).Result;

                if (shortProfileDTO == null)
                    throw new Exception("Authorization is wrong.");

                _shortProfileModel.FirstName = shortProfileDTO.FirstName ?? throw new Exception("Authorization is wrong.");
                _shortProfileModel.LastName = shortProfileDTO.LastName ?? throw new Exception("Authorization is wrong.");
                _shortProfileModel.Email = email;
            }
            catch (Exception ex)
            {
                throw new Exception($"{ex.Message}");
            }
        }
    }
}
