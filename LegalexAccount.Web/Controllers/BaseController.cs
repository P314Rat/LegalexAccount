using LegalexAccount.DAL.Models;
using LegalexAccount.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;


namespace LegalexAccount.Web.Controllers
{
    public class BaseController : Controller
    {
        protected static ProfileViewModel? _profileModel = null;


        public BaseController(IApplicationDbContextFactory _dbContextFactory, IHttpContextAccessor httpContextAccessor)
        {
            var email = httpContextAccessor.HttpContext?.User?.Claims
                .FirstOrDefault(c => c.Type == ClaimTypes.Name)?.Value;

            if (email == null)
                throw new Exception("Authorization is wrong.");

            var dbContext = _dbContextFactory.CreateDbContext("BaseController");
            var profile = dbContext.Specialists.Select(x => new { x.Email, x.FirstName, x.LastName })
                .Union(dbContext.LegalEntities.Select(x => new { x.Email, x.FirstName, x.LastName })
                .Union(dbContext.Individuals.Select(x => new { x.Email, x.FirstName, x.LastName })))
                .FirstOrDefault(x => x.Email == email);

            if (profile != null)
            {
                _profileModel = new()
                {
                    Email = email,
                    FirstName = profile.FirstName,
                    LastName = profile.LastName
                };
            }
            else
            {
                throw new Exception("Authorization is wrong.");
            }
        }
    }
}
