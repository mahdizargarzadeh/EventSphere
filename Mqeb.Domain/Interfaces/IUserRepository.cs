using System.Collections.Generic;
using Mqeb.Domain.Models.Account;
using Mqeb.Domain.ViewModels.Account;

namespace Mqeb.Domain.Interfaces
{
    public interface IUserRepository
    {
        #region Site

        User GetUserByUserName(string userName);
        User GetUserByEmail(string email);
        void UpdateUser(User user);

        #endregion

        #region Admin

        void AddUser(User user);
        bool IsExistUserName(string userName);
        bool IsExistEmail(string email);
        User GetUserById(int userId);
        UserForAdminViewModel GetUsers(int pageId = 1, string filterEmail = "", string filterUserName = "");
        int GetUserCount();

        #endregion
    }
}