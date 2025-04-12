using System.ComponentModel.DataAnnotations;

namespace Mqeb.Domain.Models.Home
{
    public class Banner
    {
        [Key]
        public int BannerId { get; set; }

        [Display(Name = "نام تصویر بنر")]
        [MaxLength(300, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد.")]
        public string BannerImageName { get; set; }

        [Display(Name = "لینک بنر")]
        public string BannerLink { get; set; }

        [Display(Name = "حذف شده / نشده")]
        public bool IsDelete { get; set; }
    }
}