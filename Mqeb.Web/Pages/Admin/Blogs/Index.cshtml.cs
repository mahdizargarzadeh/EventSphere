using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Mqeb.Application.Interfaces;
using Mqeb.Domain.ViewModels.Blog;

namespace Mqeb.Web.Pages.Admin.Blogs
{
    public class IndexModel : AdminBaseRazorPageModel
    {
        #region Constractor

        private IBlogService _blogService;

        public IndexModel(IBlogService blogService)
        {
            _blogService = blogService;
        }

        #endregion

        public BlogForAdminViewModel BlogForAdminViewModel { get; set; }

        public void OnGet(int pageId = 1, string filterTitle = "")
        {
            ViewData["pageId"] = pageId;
            BlogForAdminViewModel = _blogService.GetBlogsForAdmin(pageId, filterTitle);
        }
    }
}
