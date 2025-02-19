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
    public class DeleteUserModel : AdminBaseRazorPageModel
    {
        #region Constractor

        private IUserService _userService;

        public DeleteUserModel(IUserService userService)
        {
            _userService = userService;
        }

        #endregion

        public IActionResult OnPostDelete(int userId)
        {
            var result = _userService.DeleteUser(userId);
            if (result == DeleteUserResult.Success)
            {
                TempData[SuccessMessage] = "کاربر با موفقیت حذف شد";
            }
            return RedirectToPage("Index");
        }
    }
}
