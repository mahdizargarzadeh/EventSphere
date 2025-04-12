using Mqeb.Application.DTOs.Account;
using Mqeb.Domain.Models.Account;
using Mqeb.Domain.ViewModels.Account;

namespace Mqeb.Application.Interfaces
{
    public interface IUserService
    {
        #region Site

        LoginResult LoginUser(LoginViewModel loginViewModel);
        User GetUserByUserName(string userName);
        User GetUserByEmail(string email);
        void UpdateUser(User user);

        #endregion

        #region Admin Panel

        CreateUserResult AddUserFromAdmin(CreateUserViewModel user);
        EditUserViewModel GetUserForShowInEditMode(int userId);
        EditUserResult EditUserFromAdmin(EditUserViewModel editUser);
        InformationUserViewModel GetUserInformation(int userId);
        UserForAdminViewModel GetUsers(int pageId = 1, string filterEmail = "", string filterUserName = "");
        DeleteUserResult DeleteUser(int userId);
        int GetUserCount();

        #endregion
    }
}