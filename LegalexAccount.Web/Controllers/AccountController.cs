using AutoMapper;
using LegalexAccount.BLL.BusinessProcesses.Authorization;
using LegalexAccount.BLL.BusinessProcesses.Authorization.ForgotPassword;
using LegalexAccount.BLL.BusinessProcesses.Authorization.Login;
using LegalexAccount.BLL.BusinessProcesses.ProfileProcesses;
using LegalexAccount.BLL.DTO;
using LegalexAccount.Utility.Exceptions;
using LegalexAccount.Web.ViewModels;
using LegalexAccount.Web.ViewModels.Account;
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
        private readonly IMapper _mapper;


        public AccountController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
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

        [HttpGet]
        public IActionResult ForgotPassword()
        {
            return PartialView("_ForgotPassword");
        }

        [HttpGet]
        public async Task<IActionResult> ResetPassword(string token)
        {
            var isTokenValid = await _mediator.Send(new ResetTokenValidationQuery(token));

            if (!isTokenValid)
                return Content("Токен истек или не существует.");

            var email = await _mediator.Send(new GetEmailByTokenQuery(token));

            var model = new ResetPasswordViewModel
            {
                Email = email
            };

            return PartialView("_ResetPassword", model);
        }

        [HttpPost]
        public async Task<IActionResult> LoginAsync(LoginViewModel model)
        {
            if (!ModelState.IsValid)
                return PartialView("_Login", model);

            try
            {
                var role = await _mediator.Send(new LoginQuery(_mapper.Map<AccountDTO>(model)));
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, model.Email),
                    new Claim(ClaimTypes.Role, role.ToString())
                };
                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));

                return RedirectToAction("Orders", "Home");
            }
            catch (ValidationException ex)
            {
                ModelState.AddModelError("Email", "Неверные данные для входа");
            }
            catch
            {
                return StatusCode(500);
            }

            return PartialView("_Login", model);
        }

        [HttpPost]
        public async Task<IActionResult> ForgotPassword(ForgotPasswordViewModel model)
        {
            if (!ModelState.IsValid)
                return PartialView("_ForgotPassword", model);

            try
            {
                await _mediator.Send(new ForgotPasswordCommand(model.Email));
            }
            catch(ValidationException ex)
            {
                ModelState.AddModelError(ex.WrongFieldName, ex.Message);

                return PartialView("_ForgotPassword", model);
            }

            return PartialView("_PasswordSended");
        }

        [HttpPost]
        public async Task<IActionResult> ResetPassword(ResetPasswordViewModel model)
        {
            var resetPasswordDTO = new ResetPasswordDTO
            {
                Email = model.Email,
                NewPassword = model.NewPassword,
                RepeatPassword = model.RepeatPassword
            };

            await _mediator.Send(new EditProfileCommand(model.Email, null, resetPasswordDTO));

            return PartialView("_PasswordSended");
        }
    }
}
