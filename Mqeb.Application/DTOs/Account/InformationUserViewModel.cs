using System;
using System.ComponentModel.DataAnnotations;

namespace Mqeb.Application.DTOs.Account
{
    public class InformationUserViewModel
    {
        [Display(Name = "نام کاربری")]
        public string UserName { get; set; }

        [Display(Name = "نام")]
        public string FirstName { get; set; }

        [Display(Name = "نام خانوادگی")]
        public string LastName { get; set; }

        [Display(Name = "ایمیل")]
        public string Email { get; set; }

        [Display(Name = "تاریخ ثبت نام")]
        public DateTime CreateDate { get; set; }

        [Display(Name = "تصویر پروفایل")]
        public string AvatarName { get; set; }
    }
}