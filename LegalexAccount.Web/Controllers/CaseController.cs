using LegalexAccount.DAL.Models;
using LegalexAccount.Web.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;


namespace LegalexAccount.Web.Controllers
{
    [Authorize]
    public class CaseController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private static UserViewModel _userModel;


        public CaseController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public IActionResult CreateCase()
        {
            var email = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Name)?.Value;

            if (email == null)
                return BadRequest();

            var user = _unitOfWork.Users.GetByEmail(email);
            _userModel = new UserViewModel
            {
                Email = user.Email ?? string.Empty,
                FirstName = user.FirstName,
                LastName = user.LastName
            };

            ViewData["UserViewModel"] = _userModel;
            ViewData["StepNumber"] = 1;

            return View();
        }
    }
}
