using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Mqeb.Application.Interfaces;
using Mqeb.Domain.ViewModels.Account;

namespace Mqeb.Web.Pages.Admin.Users
{
    public class IndexModel : AdminBaseRazorPageModel
    {
        #region Constractor

        private IUserService _userService;

        public IndexModel(IUserService userService)
        {
            _userService = userService;
        }

        #endregion

        public UserForAdminViewModel UserForAdminViewModel { get; set; }

        public void OnGet(int pageId = 1, string filterUserName = "", string filterEmail = "")
        {
            UserForAdminViewModel = _userService.GetUsers(pageId, filterEmail, filterUserName);
        }
    }
}
