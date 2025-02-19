using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Mqeb.Application.Interfaces;

namespace Mqeb.Web.Pages.Admin
{
    public class IndexModel : AdminBaseRazorPageModel
    {
        #region Constractor

        IHomeService _homeService;
        IUserService _userService;
        IBlogService _blogService;

        public IndexModel(IHomeService homeService, IUserService userService, IBlogService blogService)
        {
            _homeService = homeService;
            _userService = userService;
            _blogService = blogService;
        }

        #endregion

        public void OnGet()
        {
            ViewData["UserCount"] = _userService.GetUserCount();
            ViewData["BlogCount"] = _blogService.GetBlogCount();
            ViewData["BannerCount"] = _homeService.GetBannerCount();
        }
    }
}
