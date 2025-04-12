using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace Mqeb.Application.DTOs.Blog
{
    public class CreateBlogViewModel
    {
        [Required(ErrorMessage = "لطفا {0} را وارد نمایید")]
        public int UserId { get; set; }

        [Display(Name = "گروه")]
        [Required(ErrorMessage = "لطفا {0} را وارد نمایید")]
        public int CategoryId { get; set; }

        [Display(Name = "زیرگروه")]
        public int? SubCategory { get; set; }

        [Display(Name = "عنوان")]
        [Required(ErrorMessage = "لطفا {0} را وارد نمایید")]
        [MaxLength(200, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد.")]
        public string BlogTitle { get; set; }

        [Display(Name = "توضیحات")]
        [Required(ErrorMessage = "لطفا {0} را وارد نمایید")]
        public string BlogDescription { get; set; }

        [Display(Name = "توضیحات برای نمایش در باکس")]
        [Required(ErrorMessage = "لطفا {0} را وارد نمایید")]
        [MaxLength(150, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد.")]
        public string LowDescription { get; set; }

        [Display(Name = "ویدئو ها")]
        [MaxLength(2000, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد.")]
        public string BlogVideos { get; set; }

        [Display(Name = "تگ ها")]
        [Required(ErrorMessage = "لطفا {0} را وارد نمایید")]
        [MaxLength(200, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد.")]
        public string Tags { get; set; }

        [MaxLength(200, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد.")]
        public string BlogImageName { get; set; }

        [Display(Name = "گالری بلاگ")]
        public string BlogGalleryImages { get; set; }

        [Display(Name = "پوستر بلاگ")]
        [Required(ErrorMessage = "لطفا {0} را وارد نمایید")]
        public IFormFile BlogPoster { get; set; }
    }
}