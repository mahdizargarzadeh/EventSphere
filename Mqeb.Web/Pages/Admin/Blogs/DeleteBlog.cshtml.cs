using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Mqeb.Application.DTOs.Account;
using Mqeb.Application.Interfaces;

namespace Mqeb.Web.Pages.Admin.Blogs
{
    public class DeleteBlogModel : AdminBaseRazorPageModel
    {
        #region Constractor

        private IBlogService _blogService;

        public DeleteBlogModel(IBlogService blogService)
        {
            _blogService = blogService;
        }

        #endregion

        public IActionResult OnPostDelete(int blogId)
        {
            _blogService.DeleteBlog(blogId);
            TempData[SuccessMessage] = "کاربر با موفقیت حذف شد";
            return RedirectToPage("Index");
        }
    }
}
