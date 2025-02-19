using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Mqeb.Application.Interfaces;

namespace Mqeb.Web.Pages.Admin.Categories
{
    public class DeleteCategoryModel : AdminBaseRazorPageModel
    {
        #region Constractor

        private IBlogService _blogService;

        public DeleteCategoryModel(IBlogService blogService)
        {
            _blogService = blogService;
        }

        #endregion

        public IActionResult OnPostDelete(int id)
        {
            _blogService.DeleteCategory(id);
            TempData[SuccessMessage] = "گروه با موفقیت حذف شد";
            return RedirectToPage("Index");
        }
    }
}
