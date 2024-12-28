using LegalexAccount.DAL;
using Microsoft.AspNetCore.Mvc;


namespace LegalexAccount.Web.Controllers
{
    public class SpecialistController : BaseController
    {
        public SpecialistController(IApplicationDbContextFactory _dbContextFactory, IHttpContextAccessor httpContextAccessor) : base(_dbContextFactory, httpContextAccessor)
        {
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
