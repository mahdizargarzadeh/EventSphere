using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Mqeb.Application.DTOs.Account;
using Mqeb.Application.Interfaces;

namespace Mqeb.Web.Pages.Admin.Users
{
    public class EditUserModel : AdminBaseRazorPageModel
    {
        #region Constractor

        private IUserService _userService;

        public EditUserModel(IUserService userService)
        {
            _userService = userService;
        }

        #endregion

        [BindProperty]
        public EditUserViewModel EditUserViewModel { get; set; }

        public void OnGet(int id)
        {
            EditUserViewModel = _userService.GetUserForShowInEditMode(id);
        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                var result = _userService.EditUserFromAdmin(EditUserViewModel);
                switch (result)
                {
                    case EditUserResult.ExistEmail:
                        {
                            TempData[ErrorMessage] = "ایمیل وارد شده از قبل در سایت موجود است";
                            break;
                        }
                    case EditUserResult.ExistUserName:
                        {
                            TempData[ErrorMessage] = "نام کاربری وارد شده از قبل در سایت موجود است";
                            break;
                        }
                    case EditUserResult.InValidImage:
                        {
                            TempData[WarningMessage] = "فایل آپلود شده معتبر نمی باشد";
                            break;
                        }
                    case EditUserResult.Success:
                        {
                            TempData[SuccessMessage] = "مدیر با موفقیت ویرایش شد";
                            return RedirectToPage("Index");
                        }
                }
            }

            return Page();
        }
    }
}
