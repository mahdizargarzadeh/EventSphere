using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using Mqeb.Domain.Models.Account;
using Mqeb.Domain.Models.Blog;
using Mqeb.Domain.Models.Home;

namespace Mqeb.Infra.Data.Context
{
    public class MqebContext:DbContext
    {
        public MqebContext(DbContextOptions<MqebContext> options):base(options)
        {
            
        }

        #region Account

        public DbSet<User> Users { get; set; }

        #endregion

        #region Home

        public DbSet<Banner> Banners { get; set; }
        public DbSet<AboutUs> AboutUses { get; set; }
        public DbSet<ContactUs> ContactUses { get; set; }
        public DbSet<NewsLetter> NewsLetters { get; set; }

        #endregion

        #region Blog

        public DbSet<Category> Categories { get; set; }
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<BlogGallery> BlogGalleries { get; set; }

        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasQueryFilter(u => !u.IsDelete);

            modelBuilder.Entity<Category>()
                .HasQueryFilter(c => !c.IsDelete);

            modelBuilder.Entity<Blog>()
                .HasQueryFilter(b => !b.IsDelete);

            modelBuilder.Entity<Banner>()
                .HasQueryFilter(b => !b.IsDelete);

            modelBuilder.Entity<Blog>()
                .HasOne<Category>(f => f.Category)
                .WithMany(g => g.Blogs)
                .HasForeignKey(f => f.CategoryId);

            modelBuilder.Entity<Blog>()
                .HasOne<Category>(f => f.Group)
                .WithMany(g => g.SubCategory)
                .HasForeignKey(f => f.SubCategory);

            base.OnModelCreating(modelBuilder);
        }
    }
}