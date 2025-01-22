using LegalexAccount.DAL;
using LegalexAccount.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;


namespace LegalexAccount.Web.Controllers
{
    public class BaseController : Controller
    {
        protected static ProfileViewModel? _profileModel = null;


        public BaseController(IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor)
        {
            var email = httpContextAccessor.HttpContext?.User?.Claims
                .FirstOrDefault(c => c.Type == ClaimTypes.Name)?.Value;

            if (email == null)
                throw new Exception("Authorization is wrong.");

            var userDTO = unitOfWork.Users.GetByEmailAsync(email).Result;

            if (userDTO != null)
            {
                _profileModel = new()
                {
                    Email = email,
                    FirstName = userDTO.FirstName,
                    LastName = userDTO.LastName
                };
            }
            else
            {
                throw new Exception("Authorization is wrong.");
            }
        }
    }
}
