using System.ComponentModel.DataAnnotations;

namespace Mqeb.Domain.Models.Home
{
    public class AboutUs
    {
        [Key]
        public int AboutUsId { get; set; }

        [Display(Name = "توضیحات")]
        [Required(ErrorMessage = "لطفا {0} را وارد نمایید")]
        public string AboutDescription { get; set; } 
    }
}