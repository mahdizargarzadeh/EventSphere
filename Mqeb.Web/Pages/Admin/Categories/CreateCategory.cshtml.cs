using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Mqeb.Application.Interfaces;
using Mqeb.Domain.Models.Blog;

namespace Mqeb.Web.Pages.Admin.Categories
{
    public class CreateCategoryModel : AdminBaseRazorPageModel
    {
        #region Constractor

        private IBlogService _blogService;

        public CreateCategoryModel(IBlogService blogService)
        {
            _blogService = blogService;
        }

        #endregion

        [BindProperty]
        public Category Category { get; set; }

        public void OnGet(int? id)
        {
            Category = new Category()
            {
                ParentID = id
            };
        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                _blogService.AddCategory(Category);
                TempData[SuccessMessage] = "گروه با موفقیت اضافه شد";
                return Redirect("/Admin/Categories/Index");
            }

            return Page();
        }
    }
}
