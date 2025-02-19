using System;

namespace Mqeb.Domain.ViewModels.Blog
{
    public class BlogForLatestContent
    {
        public int BlogId { get; set; }
        public string Title { get; set; }
        public DateTime CreateDate { get; set; }
        public string ImageName { get; set; }
    }
}
