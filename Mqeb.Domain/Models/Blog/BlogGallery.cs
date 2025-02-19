using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mqeb.Domain.Models.Blog
{
    public class BlogGallery
    {
        #region Properties

        [Key]
        public int BlogGalleryId { get; set; }

        [Required]
        public int BlogId { get; set; }

        [Display(Name = "تصویر")]
        public string ImageName { get; set; }

        #endregion

        #region Relations

        [ForeignKey("BlogId")]
        public Blog Blog { get; set; }

        #endregion
    }
}
