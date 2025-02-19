using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace Mqeb.Application.DTOs.Account
{
    public class EditUserViewModel
    {
        public int UserId { get; set; }

        [Display(Name = "نام کاربری")]
        [MaxLength(200, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد.")]
        [Required(ErrorMessage = "لطفا {0} را وارد نمایید")]
        public string UserName { get; set; }

        [Display(Name = "نام")]
        [MaxLength(200, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد.")]
        [Required(ErrorMessage = "لطفا {0} را وارد نمایید")]
        public string FirstName { get; set; }

        [Display(Name = "نام خانوادگی")]
        [MaxLength(200, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد.")]
        [Required(ErrorMessage = "لطفا {0} را وارد نمایید")]
        public string LastName { get; set; }

        [Display(Name = "ایمیل")]
        [MaxLength(200, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد.")]
        [Required(ErrorMessage = "لطفا {0} را وارد نمایید")]
        [EmailAddress(ErrorMessage = "{0} وارد شده صحیح نمی باشد")]
        public string Email { get; set; }

        [Display(Name = "رمز عبور")]
        [MaxLength(200, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد.")]
        [RegularExpression(@"^(?=.*[A-Za-z])(?=.*\d)[A-Za-z\d]{6,20}$", ErrorMessage = "کلمه عبور باید شامل حرف و عدد باشد")]
        public string Password { get; set; }

        [Display(Name = "ادمین هست / نیست")]
        public bool IsAdmin { get; set; }

        [Display(Name = "تصویر پروفایل")]
        public IFormFile UserAvatar { get; set; }

        [Display(Name = "تصویر پروفایل")]
        [MaxLength(200, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد.")]
        public string AvatarName { get; set; }
    }

    public enum EditUserResult
    {
        Success,
        ExistEmail,
        ExistUserName,
        InValidImage
    }
}