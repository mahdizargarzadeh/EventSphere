using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.StaticFiles;
using Mqeb.Application.Convertors;
using Mqeb.Application.DTOs.Blog;
using Mqeb.Application.DTOs.Home;
using Mqeb.Application.Interfaces;
using Mqeb.Application.Sender;
using Mqeb.Domain.Models.Blog;

namespace Mqeb.Web.Pages.Admin.Blogs
{
    public class CreateBlogModel : AdminBaseRazorPageModel
    {
        #region Constractor

        private IBlogService _blogService;
        private IHomeService _homeService;
        private IViewRenderService _viewService;

        public CreateBlogModel(IBlogService blogService, IHomeService homeService, IViewRenderService viewService)
        {
            _blogService = blogService;
            _homeService = homeService;
            _viewService = viewService;
        }

        #endregion

        [BindProperty]
        public CreateBlogViewModel CreateBlogViewModel { get; set; }

        public void OnGet()
        {
            var groups = _blogService.GetCategoryForManageBlog();
            ViewData["Categories"] = new SelectList(groups, "Value", "Text");

            if (groups.Count != 0)
            {
                var subGroups = _blogService.GetSubCategoryForManageBlog(int.Parse(groups.First().Value));
                ViewData["SubGroups"] = new SelectList(subGroups, "Value", "Text");
            }
        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                var userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
                CreateBlogViewModel.UserId = userId;
                var blogId = _blogService.AddBlog(CreateBlogViewModel);
                if (CreateBlogViewModel.BlogGalleryImages != null)
                {
                    string[] fileNames = CreateBlogViewModel.BlogGalleryImages.Split(",");
                    _blogService.AddGalleryToBlog(fileNames, blogId);
                }
                
                TempData[SuccessMessage] = "عملیات با موفقیت انجام شد";

                #region SendEmail

                try
                {
                    SendEmailViewModel model = new SendEmailViewModel();
                    model.Message = "انتشار خبرنامه جدید در سایت موسسه قرآن و عترت بینه";
                    string bodyEmail = _viewService.RenderToStringAsync("_EmailSender", model);

                    var newsLetter = _homeService.GetNewsLetter();

                    foreach (var item in newsLetter)
                    {
                        SendEmail.Send(item.Email, CreateBlogViewModel.LowDescription, bodyEmail);
                    }
                }
                catch
                {
                    return RedirectToPage("Index");
                }

                #endregion

                return RedirectToPage("Index");
            }

            return Page();
        }
    }
}
