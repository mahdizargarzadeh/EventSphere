using System.ComponentModel.DataAnnotations;

namespace Mqeb.Application.DTOs.Home
{
    public class SendNewsLetterViewModel
    {
        [Display(Name = "عنوان پیام")]
        [MaxLength(200, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد.")]
        [Required(ErrorMessage = "لطفا {0} را وارد نمایید")]
        public string Title { get; set; }

        [Display(Name = "توضیحات")]
        [Required(ErrorMessage = "لطفا {0} را وارد نمایید")]
        public string Description { get; set; }
    }
}