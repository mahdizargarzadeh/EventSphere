using System;
using Microsoft.AspNetCore.Mvc;
using Mqeb.Application.Interfaces;
using System.Collections.Generic;
using Mqeb.Application.Utilities;

namespace Mqeb.Web.Controllers
{
    public class BlogController : SiteBaseController
    {
        #region Constractor

        private IBlogService _blogService;
        public BlogController(IBlogService blogService)
        {
            _blogService = blogService;
        }

        #endregion

        public IActionResult Index(int pageId = 1 ,string filter = "", List<int> selectedGroups = null)
        {
            ViewBag.pageId = pageId;
            return View(_blogService.GetBlogs(pageId,filter,9, selectedGroups));
        }

        [Route("Blog/{id}/{title}")]
        public IActionResult ShowBlog(int id, string title)
        {
            var blog = _blogService.GetBlogForShow(id);

            if(blog == null)
            {
                return NotFound();
            }

            return View(blog);
        }

        [Route("b/{key}")]
        public IActionResult ShortKeyRedirect(int key)
        {
            var blog = _blogService.GetBlogById(key);

            if (blog == null)
            {
                return NotFound();
            }

            Uri uri = new Uri($"https://localhost:44398/Blog/{blog.BlogId}/{blog.BlogTitle.ToSlug()}");
            return Redirect(uri.AbsoluteUri);
        }

    }
}
