using System.Collections.Generic;
using Mqeb.Domain.Models.Account;

namespace Mqeb.Domain.ViewModels.Account
{
    public class UserForAdminViewModel
    {
        public List<User> Users { get; set; }
        public int CurrentPage { get; set; }
        public int PageCount { get; set; }
    }
}