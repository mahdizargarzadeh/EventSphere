using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using Mqeb.Application.DTOs.Blog;
using Mqeb.Domain.Models.Blog;
using Mqeb.Domain.ViewModels.Blog;
using Mqeb.Domain.ViewModels.Category;

namespace Mqeb.Application.Interfaces
{
    public interface IBlogService
    {
        #region Category

        void AddCategory(Category category);
        Category GetCategoryById(int categoryId);
        void UpdateCategory(Category category);
        List<Category> GetAllGroup();
        void DeleteCategory(int categoryId);

        #endregion

        #region Blog

        int AddBlog(CreateBlogViewModel blog);
        void UpdateBlog(EditBlogViewModel editBlog);
        BlogForAdminViewModel GetBlogsForAdmin(int pageId = 1, string filterTitle = "");
        EditBlogViewModel GetBlogById(int blogId);
        void DeleteBlog(int blogId);
        Tuple<List<ShowBlogListItemViewModel>, int> GetBlogs(int pageId = 1,string filter = "", int take = 0, List<int> selectedGroups = null);
        Blog GetBlogForShow(int blogId);
        List<BlogForLatestContent> GetBlogsForLatestContent();
        List<CategoriesForShowInBlogPages> GetCategoriesForShowInBlogPages();
        List<SelectListItem> GetCategoryForManageBlog();
        List<SelectListItem> GetSubCategoryForManageBlog(int groupId);
        List<Category> GetAllCategory();
        int GetBlogCount();
        void AddGalleryToBlog(string[] fileNames, int blodId);

        #endregion
    }
}