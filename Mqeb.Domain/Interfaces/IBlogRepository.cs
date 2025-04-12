using System;
using System.Collections.Generic;
using Mqeb.Domain.Models.Blog;
using Mqeb.Domain.ViewModels.Blog;
using Microsoft.AspNetCore.Mvc.Rendering;
using Mqeb.Domain.ViewModels.Category;

namespace Mqeb.Domain.Interfaces
{
    public interface IBlogRepository
    {
        #region Category

        void AddCategory(Category category);
        Category GetCategoryById(int categoryId);
        void UpdateCategory(Category category);
        List<Category> GetAllGroup();
        void DeleteCategory(int categoryId);

        #endregion

        #region Blog

        int AddBlog(Blog blog);
        void EditBlog(Blog blog);
        BlogForAdminViewModel GetBlogsForAdmin(int pageId = 1, string filterTitle = "");
        Blog GetBlogById(int blogId);
        void DeleteBlog(int blogId);
        Tuple<List<ShowBlogListItemViewModel>,int> GetBlogs(int pageId = 1, string filter = "", int take = 0, List<int> selectedGroups = null);
        Blog GetBlogForShow(int blogId);
        List<BlogForLatestContent> GetBlogsForLatestContent();
        List<CategoriesForShowInBlogPages> GetCategoriesForShowInBlogPages();
        List<SelectListItem> GetCategoryForManageBlog();
        List<SelectListItem> GetSubCategoryForManageBlog(int groupId);
        public List<Category> GetAllCategory();
        int GetBlogCount();
        void AddGalleryToBlog(string[] fileNames, int blodId);
        List<BlogGallery> GetBlogGalleriesByBlogId(int blogId);

        #endregion
    }
}