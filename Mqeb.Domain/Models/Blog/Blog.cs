using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Mqeb.Domain.Models.Account;

namespace Mqeb.Domain.Models.Blog
{
    public class Blog
    {
        #region Properties

        [Key]
        public int BlogId { get; set; }

        [Required(ErrorMessage = "لطفا {0} را وارد نمایید")]
        public int UserId { get; set; }

        [Required]
        public int CategoryId { get; set; }

        public int? SubCategory { get; set; }

        [Display(Name = "عنوان")]
        [Required(ErrorMessage = "لطفا {0} را وارد نمایید")]
        [MaxLength(200, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد.")]
        public string BlogTitle { get; set; }

        [Display(Name = "توضیحات")]
        [Required(ErrorMessage = "لطفا {0} را وارد نمایید")]
        public string BlogDescription { get; set; }

        [Display(Name = "توضیحات برای نمایش باکس")]
        [Required(ErrorMessage = "لطفا {0} را وارد نمایید")]
        public string LowDescription { get; set; }

        [Display(Name = "تگ ها")]
        [Required(ErrorMessage = "لطفا {0} را وارد نمایید")]
        [MaxLength(200, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد.")]
        public string Tags { get; set; }

        [Display(Name = "ویدئو ها")]
        [MaxLength(2000, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد.")]
        public string BlogVideos { get; set; }

        [MaxLength(200, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد.")]
        public string BlogImageName { get; set; }

        [Display(Name = "حذف شده / نشده")]
        public bool IsDelete { get; set; }

        [Display(Name = "تاریخ ثبت")]
        public DateTime CreateDate { get; set; }

        [Display(Name = "تاریخ آخرین بروزرسانی")]
        public DateTime? UpdateDate { get; set; }

        #endregion

        #region Relations

        [ForeignKey("UserId")]
        public User User { get; set; }

        [ForeignKey("CategoryId")]
        public Category Category { get; set; }

        [ForeignKey("SubCategory")]
        public Category Group { get; set; }

        public List<BlogGallery> BlogGalleries { get; set; }

        #endregion
    }
}