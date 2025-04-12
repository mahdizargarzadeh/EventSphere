using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using Mqeb.Application.Convertors;
using Mqeb.Application.DTOs.Account;
using Mqeb.Application.DTOs.Blog;
using Mqeb.Application.Generator;
using Mqeb.Application.Interfaces;
using Mqeb.Application.Utilities;
using Mqeb.Domain.Interfaces;
using Mqeb.Domain.Models.Account;
using Mqeb.Domain.Models.Blog;
using Mqeb.Domain.ViewModels.Blog;
using Mqeb.Domain.ViewModels.Category;

namespace Mqeb.Application.Services
{
    public class BlogService : IBlogService
    {
        #region Constractor

        private IBlogRepository _blogRepository;

        public BlogService(IBlogRepository blogRepository)
        {
            _blogRepository = blogRepository;
        }

        #endregion


        public void AddCategory(Category category)
        {
            _blogRepository.AddCategory(category);
        }

        public Category GetCategoryById(int categoryId)
        {
            return _blogRepository.GetCategoryById(categoryId);
        }

        public void UpdateCategory(Category category)
        {
            _blogRepository.UpdateCategory(category);
        }

        public List<Category> GetAllGroup()
        {
            return _blogRepository.GetAllGroup();
        }

        public void DeleteCategory(int categoryId)
        {
            _blogRepository.DeleteCategory(categoryId);
        }

        public int AddBlog(CreateBlogViewModel blog)
        {
            var newBlog = new Blog()
            {
                UserId = blog.UserId,
                CategoryId = blog.CategoryId,
                SubCategory = blog.SubCategory,
                BlogTitle = blog.BlogTitle,
                BlogDescription = blog.BlogDescription,
                LowDescription = blog.LowDescription,
                Tags = blog.Tags,
                BlogVideos = blog.BlogVideos,
                CreateDate = DateTime.Now,
                UpdateDate = DateTime.Now,
                IsDelete = false
            };

            #region SavePoster

            if (blog.BlogPoster != null && ImageValidation.Validate(blog.BlogPoster.FileName))
            {
                newBlog.BlogImageName = NameGenerator.GenerateUniqCode() + Path.GetExtension(blog.BlogPoster.FileName);
                string imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Blog/Poster/Big", newBlog.BlogImageName);

                using (var stream = new FileStream(imagePath, FileMode.Create))
                {
                    blog.BlogPoster.CopyTo(stream);
                }

                ImageConvertor imgResize = new ImageConvertor();

                string thumbPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Blog/Poster/Small", newBlog.BlogImageName);

                imgResize.Image_resize(imagePath, thumbPath, 500);
            }

            #endregion

            return _blogRepository.AddBlog(newBlog);
        }

        public void UpdateBlog(EditBlogViewModel editBlog)
        {
            Blog blog = _blogRepository.GetBlogById(editBlog.BlogId);

            blog.CategoryId = editBlog.CategoryId;
            blog.SubCategory = editBlog.SubCategory;
            blog.BlogTitle = editBlog.BlogTitle;
            blog.BlogDescription = editBlog.BlogDescription;
            blog.LowDescription = editBlog.LowDescription;
            blog.Tags = editBlog.Tags;
            blog.BlogVideos = editBlog.BlogVideos;
            blog.UpdateDate = DateTime.Now;

            #region EditPoster

            if (editBlog.BlogPoster != null && ImageValidation.Validate(editBlog.BlogPoster.FileName))
            {
                string deleteImagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Blog/Poster/Big", editBlog.BlogImageName);
                if (File.Exists(deleteImagePath))
                {
                    File.Delete(deleteImagePath);
                }

                string deleteThumbPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Blog/Poster/Small", editBlog.BlogImageName);
                if (File.Exists(deleteThumbPath))
                {
                    File.Delete(deleteThumbPath);
                }

                blog.BlogImageName = NameGenerator.GenerateUniqCode() + Path.GetExtension(editBlog.BlogPoster.FileName);
                string imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Blog/Poster/Big", blog.BlogImageName); ;

                using (var stream = new FileStream(imagePath, FileMode.Create))
                {
                    editBlog.BlogPoster.CopyTo(stream);
                }

                ImageConvertor imgResize = new ImageConvertor();

                string thumbPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Blog/Poster/Small", blog.BlogImageName);

                imgResize.Image_resize(imagePath, thumbPath, 500);
            }

            #endregion

            _blogRepository.EditBlog(blog);
        }

        public BlogForAdminViewModel GetBlogsForAdmin(int pageId = 1, string filterTitle = "")
        {
            return _blogRepository.GetBlogsForAdmin(pageId, filterTitle);
        }

        public EditBlogViewModel GetBlogById(int blogId)
        {
            var blog = _blogRepository.GetBlogById(blogId);
            return new EditBlogViewModel()
            {
                BlogId = blogId,
                BlogTitle = blog.BlogTitle,
                BlogDescription = blog.BlogDescription,
                LowDescription = blog.LowDescription,
                BlogImageName = blog.BlogImageName,
                Tags = blog.Tags,
                UpdateDate = blog.UpdateDate
            };
        }

        public void DeleteBlog(int blogId)
        {
            #region DeletePoster

            var blog = _blogRepository.GetBlogById(blogId);

            string deleteBigImagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Blog/Poster/Big", blog.BlogImageName);
            if (File.Exists(deleteBigImagePath))
            {
                File.Delete(deleteBigImagePath);
            }

            string deleteSmallImagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Blog/Poster/Small", blog.BlogImageName);
            if (File.Exists(deleteSmallImagePath))
            {
                File.Delete(deleteSmallImagePath);
            }

            #endregion

            #region DeleteBlogGalleryImages

            var blogGalleries = _blogRepository.GetBlogGalleriesByBlogId(blogId);
            if(blogGalleries != null)
            {
                foreach (var item in blogGalleries)
                {
                    string deleteBlogGalleryImagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/BlogGallery", item.ImageName);
                    if (File.Exists(deleteBlogGalleryImagePath))
                    {
                        File.Delete(deleteBlogGalleryImagePath);
                    }
                }
            }

            #endregion

            _blogRepository.DeleteBlog(blogId);
        }

        public Tuple<List<ShowBlogListItemViewModel>,int> GetBlogs(int pageId = 1, string filter = "", int take = 0, List<int> selectedGroups = null)
        {
            return _blogRepository.GetBlogs(pageId, filter, take, selectedGroups);
        }

        public Blog GetBlogForShow(int blogId)
        {
            return _blogRepository.GetBlogForShow(blogId);
        }

        public List<BlogForLatestContent> GetBlogsForLatestContent()
        {
            return _blogRepository.GetBlogsForLatestContent();
        }

        public List<SelectListItem> GetCategoryForManageBlog()
        {
            return _blogRepository.GetCategoryForManageBlog();
        }

        public List<SelectListItem> GetSubCategoryForManageBlog(int groupId)
        {
            return _blogRepository.GetSubCategoryForManageBlog(groupId);
        }

        public List<CategoriesForShowInBlogPages> GetCategoriesForShowInBlogPages()
        {
            return _blogRepository.GetCategoriesForShowInBlogPages();
        }

        public List<Category> GetAllCategory()
        {
            return _blogRepository.GetAllCategory();
        }

        public int GetBlogCount()
        {
            return _blogRepository.GetBlogCount();
        }

        public void AddGalleryToBlog(string[] fileNames, int blodId)
        {
            _blogRepository.AddGalleryToBlog(fileNames, blodId);
        }
    }
}