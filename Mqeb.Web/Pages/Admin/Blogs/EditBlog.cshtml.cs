using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Mqeb.Application.DTOs.Blog;
using Mqeb.Application.Interfaces;

namespace Mqeb.Web.Pages.Admin.Blogs
{
    public class EditBlogModel : AdminBaseRazorPageModel
    {
        #region Constractor

        private IBlogService _blogService;

        public EditBlogModel(IBlogService blogService)
        {
            _blogService = blogService;
        }

        #endregion

        [BindProperty]
        public EditBlogViewModel EditBlogViewModel { get; set; }

        public void OnGet(int id)
        {
            EditBlogViewModel = _blogService.GetBlogById(id);

            var groups = _blogService.GetCategoryForManageBlog();
            ViewData["Categories"] = new SelectList(groups, "Value", "Text");

            List<SelectListItem> subgroups = new List<SelectListItem>()
            {
                new SelectListItem(){Text = "انتخاب کنید", Value = ""}
            };

            subgroups.AddRange(_blogService.GetSubCategoryForManageBlog(EditBlogViewModel.CategoryId));
            string selectedSubGroup = null;

            if (EditBlogViewModel.SubCategory != null)
            {
                selectedSubGroup = EditBlogViewModel.SubCategory.ToString();
            }

            var subGroups = _blogService.GetSubCategoryForManageBlog(int.Parse(groups.First().Value));
            ViewData["SubGroups"] = new SelectList(subGroups, "Value", "Text");
        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                _blogService.UpdateBlog(EditBlogViewModel);
                TempData[SuccessMessage] = "عملیات با موفقیت انجام شد";
                return RedirectToPage("Index");
            }

            return Page();
        }
    }
}
