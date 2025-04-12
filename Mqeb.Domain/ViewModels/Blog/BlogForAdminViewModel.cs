using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Mqeb.Domain.ViewModels.Blog
{
    public class BlogForAdminViewModel
    {
        public List<Models.Blog.Blog> Blogs { get; set; }
        public int CurrentPage { get; set; }
        public int PageCount { get; set; }
    }
}