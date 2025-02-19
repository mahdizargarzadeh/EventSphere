using System.Collections.Generic;
using Mqeb.Domain.Models.Home;

namespace Mqeb.Domain.ViewModels.Home
{
    public class ContactUsForAdminViewModel
    {
        public List<ContactUs> ContactUses { get; set; }
        public int CurrentPage { get; set; }
        public int PageCount { get; set; }
    }
}