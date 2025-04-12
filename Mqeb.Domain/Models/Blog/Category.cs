using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mqeb.Domain.Models.Blog
{
    public class Category
    {
        #region Properties

        [Key]
        public int CategoryId { get; set; }

        [Display(Name = "عنوان گروه")]
        [Required(ErrorMessage = "لطفا {0} را وارد نمایید")]
        [MaxLength(200, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد.")]
        public string CategoryTitle { get; set; }

        [Display(Name = "حذف شده / نشده")]
        public bool IsDelete { get; set; }

        [Display(Name = "گروه اصلی")]
        public int? ParentID { get; set; }

        #endregion

        #region Relations

        [ForeignKey("ParentID")]
        public List<Category> Categories { get; set; }

        [InverseProperty("Category")]
        public List<Blog> Blogs { get; set; }

        [InverseProperty("Group")]
        public List<Blog> SubCategory { get; set; }

        #endregion
    }
}