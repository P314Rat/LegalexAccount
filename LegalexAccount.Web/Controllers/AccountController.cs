﻿using LegalexAccount.BLL.BusinessProcesses.Authorization;
using LegalexAccount.BLL.DTO;
using LegalexAccount.Utility.Extensions;
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

        [HttpGet]
        public IActionResult ForgotPassword()
        {
            return PartialView("_ForgotPassword");
        }

        [HttpPost]
        public async Task<IActionResult> ForgotPassword(ForgotPasswordViewModel model)
        {
            await _mediator.Send(new ForgotPasswordCommand(model.Email));

            return PartialView("_PasswordSended");
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

                var role = await _mediator.Send(new LoginQuery(modelDTO));
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, modelDTO.Email),
                    new Claim(ClaimTypes.Role, role.ToString())
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
