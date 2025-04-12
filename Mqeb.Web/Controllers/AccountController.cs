using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Mqeb.Application.Convertors;
using Mqeb.Application.DTOs.Account;
using Mqeb.Application.Interfaces;
using Mqeb.Application.Sender;
using TopLearn.Core.Security;

namespace Mqeb.Web.Controllers
{
    public class AccountController : SiteBaseController
    {
        #region Constractor

        private IUserService _userService;
        private IGoogleRecaptcha _googleRecaptcha;

        public AccountController(IUserService userService, IGoogleRecaptcha googleRecaptcha)
        {
            _userService = userService;
            _googleRecaptcha = googleRecaptcha;
        }

        #endregion

        #region Login

        [Route("Login")]
        public IActionResult Login()
        {
            return View();
        }

        [Route("Login")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel login)
        {
            if (!await _googleRecaptcha.IsSatisfy())
            {
                TempData[WarningMessage] = "اعتبار سنجی captcha نا موفق بود!";
                return View(login);
            }

            if (ModelState.IsValid)
            {
                var result = _userService.LoginUser(login);
                switch (result)
                {
                    case LoginResult.NotFound:
                    {
                        TempData[ErrorMessage] = "کاربری با این اطلاعات یافت نشد";
                        break;
                    }
                    case LoginResult.Success:
                    {
                        var user = _userService.GetUserByUserName(login.UserName);
                        var claims = new List<Claim>
                        {
                            new Claim(ClaimTypes.NameIdentifier, user.UserId.ToString()),
                            new Claim(ClaimTypes.Name, user.FirstName + " " + user.LastName),
                            new Claim("IsAdmin", user.IsAdmin.ToString())
                        };

                        var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                        var principal = new ClaimsPrincipal(identity);

                        var properties = new AuthenticationProperties()
                        {
                            IsPersistent = login.RememberMe
                        };

                        await HttpContext.SignInAsync(principal, properties);
                        TempData[SuccessMessage] = "شما با موفقیت وارد حساب کاربری خود شدید";
                        if (user.IsAdmin == true)
                        {
                            return Redirect("/Admin");
                        }
                        else
                        {
                            return Redirect("/");
                        }
                    }
                }
            }

            return View(login);
        }

        #endregion

        #region Logout

        [Route("Logout")]
        public IActionResult Logout()
        {
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            TempData[SuccessMessage] = "شما از حساب کاربری خود خارج شدید";
            return Redirect("/");
        }

        #endregion

        #region Forgot Password

        [Route("ForgotPassword")]
        public IActionResult ForgotPassword()
        {
            return View();
        }

        [HttpPost]
        [Route("ForgotPassword")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ForgotPassword(ForgotPasswordViewModel forgot)
        {
            if (!await _googleRecaptcha.IsSatisfy())
            {
                TempData[WarningMessage] = "اعتبار سنجی captcha نا موفق بود!";
                return View(forgot);
            }

            if (ModelState.IsValid)
            {
                string fixedEmail = FixedText.FixEmail(forgot.Email);
                var user = _userService.GetUserByEmail(forgot.Email);
                if (user == null)
                {
                    TempData[ErrorMessage] = "کاربری یافت نشد";
                    return View(forgot);
                }

                Random random = new Random();
                int newPassword = random.Next(100000, 999999);

                user.Password = PasswordHelper.EncodePasswordMd5(newPassword.ToString());
                _userService.UpdateUser(user);

                string bodyText = $"رمز عبوز شما به {newPassword} تغییر کرد برای ورود از این کلمه عبور استفاده کنید.";
                SendEmail.Send(forgot.Email, "فراموشی رمز عبور", bodyText);

                TempData[SuccessMessage] = "رمز عبور جدید برای ایمیل ارسال شد";

                return RedirectToAction("Login");

            }

            return View(forgot);
        }

        #endregion
    }
}