using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Mqeb.Application.DTOs.Account;
using Mqeb.Application.Interfaces;

namespace Mqeb.Web.Pages.Admin.Users
{
    [Authorize]
    public class CreateUserModel : AdminBaseRazorPageModel
    {
        #region Constractor

        private IUserService _userService;

        public CreateUserModel(IUserService userService)
        {
            _userService = userService;
        }

        #endregion

        public void OnGet()
        {
            
        }

        [BindProperty]
        public CreateUserViewModel CreateUserViewModel { get; set; }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                var result = _userService.AddUserFromAdmin(CreateUserViewModel);

                switch (result)
                {
                    case CreateUserResult.ExistEmail:
                        {
                            TempData[ErrorMessage] = "ایمیل وارد شده از قبل در سایت موجود است";
                            break;
                        }
                    case CreateUserResult.ExistUserName:
                        {
                            TempData[ErrorMessage] = "نام کاربری وارد شده از قبل در سایت موجود است";
                            break;
                        }
                    case CreateUserResult.InValidImage:
                    {
                        TempData[WarningMessage] = "فایل آپلود شده معتبر نمی باشد";
                        break;
                    }
                    case CreateUserResult.Success:
                        {
                            TempData[SuccessMessage] = "مدیر با موفقیت اضافه شد";
                            return Redirect("/Admin/Users");
                        }
                }
            }

            return Page();

        }
    }
}
