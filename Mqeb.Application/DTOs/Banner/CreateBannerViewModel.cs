using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace Mqeb.Application.DTOs.Banner
{
    public class CreateBannerViewModel
    {
        [Display(Name = "تصویر بنر")]
        [Required(ErrorMessage = "لطفا {0} را وارد نمایید")]
        public IFormFile BannerImage { get; set; }


        [Display(Name = "لینک بنر")]
        public string BannerLink { get; set; }

        [Display(Name = "نام تصویر بنر")]
        [MaxLength(300, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد.")]
        public string BannerImageName { get; set; }
    }
}