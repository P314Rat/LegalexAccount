using LegalexAccount.BLL.BusinessProcesses.Authorization;
using LegalexAccount.BLL.DTO;
using LegalexAccount.Web.ViewModels;
using MediatR;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;


namespace LegalexAccount.Web.Controllers
{
    public class AccountController : Controller
    {
        private readonly IMediator _mediator;


        public AccountController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return PartialView("_Login");
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> LogoutAsync()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            return Redirect("Login");
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> RegisterAsync()
        {
            return Redirect("Login"); // Сделать
        }

        [HttpPost]
        public async Task<IActionResult> LoginAsync(LoginViewModel model)
        {
            if (!ModelState.IsValid)
                return PartialView("_Login", model);

            try
            {
                var modelDTO = new IdentityDTO
                {
                    Email = model.Email,
                    Password = model.Password
                };

                await _mediator.Send(new LoginQuery(modelDTO));

                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, modelDTO.Email),
                };

                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));

                return RedirectToAction("Orders", "Home");
            }
            catch
            {
                ModelState.AddModelError("Email", "Неверные данные для входа");

                return PartialView("_Login", model);
            }
        }
    }
}
