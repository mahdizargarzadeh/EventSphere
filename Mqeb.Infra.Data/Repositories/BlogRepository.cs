using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.Internal;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Mqeb.Domain.Interfaces;
using Mqeb.Domain.Models.Blog;
using Mqeb.Domain.ViewModels.Blog;
using Mqeb.Domain.ViewModels.Category;
using Mqeb.Infra.Data.Context;

namespace Mqeb.Infra.Data.Repositories
{
    public class BlogRepository : IBlogRepository
    {
        #region Constractor

        private MqebContext _context;

        public BlogRepository(MqebContext context)
        {
            _context = context;
        }

        #endregion


        public void AddCategory(Category category)
        {
            _context.Categories.Add(category);
            _context.SaveChanges();
        }

        public Category GetCategoryById(int categoryId)
        {
            return _context.Categories.Find(categoryId);
        }

        public void UpdateCategory(Category category)
        {
            _context.Categories.Update(category);
            _context.SaveChanges();
        }

        public List<Category> GetAllGroup()
        {
            return _context.Categories.Include(c => c.Categories).ToList();
        }

        public void DeleteCategory(int categoryId)
        {
            var category = GetCategoryById(categoryId);
            category.IsDelete = true;
            UpdateCategory(category);
        }

        public int AddBlog(Blog blog)
        {
            _context.Blogs.Add(blog);
            _context.SaveChanges();

            return blog.BlogId;
        }

        public void EditBlog(Blog blog)
        {
            _context.Blogs.Update(blog);
            _context.SaveChanges();
        }

        public BlogForAdminViewModel GetBlogsForAdmin(int pageId = 1, string filterTitle = "")
        {
            IQueryable<Blog> result = _context.Blogs.Include(b=>b.User);

            if (!string.IsNullOrEmpty(filterTitle))
            {
                result = result.Where(u => u.BlogTitle.Contains(filterTitle));
            }

            //Show Item In Page
            int take = 10;
            int skip = (pageId - 1) * take;
            int pageCount = result.Count(b => !b.IsDelete) / take;

            if ((pageCount % 2) != 0)
            {
                pageCount += 1;
            }

            BlogForAdminViewModel list = new BlogForAdminViewModel();
            list.CurrentPage = pageId;
            list.PageCount = pageCount;
            list.Blogs = result.OrderByDescending(u => u.CreateDate).Skip(skip).Take(take).ToList();

            return list;
        }

        public Blog GetBlogById(int blogId)
        {
            return _context.Blogs.Find(blogId);
        }

        public void DeleteBlog(int blogId)
        {
            var blog = GetBlogById(blogId);
            blog.IsDelete = true;
            _context.Blogs.Update(blog);
            _context.SaveChanges();
        }

        Tuple<List<ShowBlogListItemViewModel>, int> IBlogRepository.GetBlogs(int pageId, string filter, int take = 0, List<int> selectedGroups = null)
        {
            if(take == 0)
            {
                take = 8;
            }

            IQueryable<Blog> result = _context.Blogs.OrderByDescending(b => b.CreateDate);

            if(!string.IsNullOrEmpty(filter))
            {
                result = result.Where(b=>b.BlogTitle.Contains(filter) || b.Tags.Contains(filter));
            }

            if (selectedGroups != null && selectedGroups.Any())
            {
                foreach (int groupId in selectedGroups)
                {
                    result = result.Where(c => c.CategoryId == groupId || c.SubCategory == groupId);
                }
            }

            int skip = (pageId - 1) * take;
            int pageCount = result.Include(b => b.Category).Select(b => new ShowBlogListItemViewModel()
            {
                BlogId = b.BlogId,
                Title = b.BlogTitle,
                Description = b.LowDescription,
                ImageName = b.BlogImageName,
                Tgas = b.Tags,
                Category = b.Category.CategoryTitle,
            }).Count() / take;

            if ((pageCount % 2) != 0)
            {
                pageCount += 1;
            }

            var query = result.Include(b => b.Category).Select(b => new ShowBlogListItemViewModel()
            {
                BlogId = b.BlogId,
                Title = b.BlogTitle,
                Description = b.LowDescription,
                Tgas = b.Tags,
                ImageName = b.BlogImageName,
                Category = b.Category.CategoryTitle
            }).Skip(skip).Take(take).ToList();

            return Tuple.Create(query, pageCount);
        }

        public Blog GetBlogForShow(int blogId)
        {
            return _context.Blogs.Include(b => b.BlogGalleries)
                .SingleOrDefault(b=>b.BlogId == blogId);
        }

        public List<BlogForLatestContent> GetBlogsForLatestContent()
        {
            return _context.Blogs.OrderByDescending(b => b.CreateDate)
                .Select(b => new BlogForLatestContent()
                {
                    BlogId = b.BlogId,
                    Title = b.BlogTitle,
                    CreateDate = b.CreateDate,
                    ImageName = b.BlogImageName
                }).Take(4).ToList();
        }

        public List<CategoriesForShowInBlogPages> GetCategoriesForShowInBlogPages()
        {
            return _context.Categories.Where(c => c.ParentID == null)
                .Select(c => new CategoriesForShowInBlogPages()
                {
                    CategoryId = c.CategoryId,
                    CategoryTitle = c.CategoryTitle
                }).ToList();
        }

        public List<SelectListItem> GetCategoryForManageBlog()
        {
            return _context.Categories.Where(c => c.ParentID == null)
                .Select(g => new SelectListItem()
                {
                    Text = g.CategoryTitle,
                    Value = g.CategoryId.ToString()
                }).ToList();
        }

        public List<SelectListItem> GetSubCategoryForManageBlog(int groupId)
        {
            return _context.Categories.Where(g => g.ParentID == groupId)
                .Select(g => new SelectListItem()
                {
                    Text = g.CategoryTitle,
                    Value = g.CategoryId.ToString()
                }).ToList();
        }

        public List<Category> GetAllCategory()
        {
            return _context.Categories.Include(c => c.Categories).ToList();
        }

        public int GetBlogCount()
        {
            return _context.Blogs.Count();
        }

        public void AddGalleryToBlog(string[] fileNames, int blodId)
        {
            foreach(var item in fileNames)
            {
                _context.BlogGalleries.Add(new BlogGallery()
                {
                    BlogId = blodId,
                    ImageName = item
                });
                _context.SaveChanges();
            }
        }

        public List<BlogGallery> GetBlogGalleriesByBlogId(int blogId)
        {
            return _context.BlogGalleries.Where(g => g.BlogId == blogId).ToList();
        }
    }
}