using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Mqeb.Application.Interfaces;
using Mqeb.Application.Services;
using Mqeb.Domain.Models.Blog;

namespace Mqeb.Web.Pages.Admin.Categories
{
    public class EditCategoryModel : AdminBaseRazorPageModel
    {
        #region Constractor

        private IBlogService _blogService;

        public EditCategoryModel(IBlogService blogService)
        {
            _blogService = blogService;
        }

        #endregion

        [BindProperty]
        public Category Category { get; set; }

        public void OnGet(int id)
        {
            Category = _blogService.GetCategoryById(id);
        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                _blogService.UpdateCategory(Category);
                TempData[SuccessMessage] = "گروه با موفقیت ویرایش شد";
                return RedirectToPage("Index");
            }

            return Page();
        }
    }
}
