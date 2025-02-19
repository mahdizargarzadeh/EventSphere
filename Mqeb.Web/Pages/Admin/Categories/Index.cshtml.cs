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
    public class IndexModel : AdminBaseRazorPageModel
    {

        #region Constractor

        private IBlogService _blogService;

        public IndexModel(IBlogService blogService)
        {
            _blogService = blogService;
        }
        
        #endregion

        public List<Category> Categories { get; set; }

        public void OnGet()
        {
            Categories = _blogService.GetAllGroup();
        }
    }
}
