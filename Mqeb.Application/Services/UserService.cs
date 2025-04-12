using System;
using System.IO;
using Mqeb.Application.DTOs.Account;
using Mqeb.Application.Generator;
using Mqeb.Application.Interfaces;
using Mqeb.Application.Utilities;
using Mqeb.Domain.Interfaces;
using Mqeb.Domain.Models.Account;
using Mqeb.Domain.ViewModels.Account;
using TopLearn.Core.Security;

namespace Mqeb.Application.Services
{
    public class UserService : IUserService
    {
        #region Constractor

        private IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        #endregion

        public LoginResult LoginUser(LoginViewModel loginViewModel)
        {
            var user = _userRepository.GetUserByUserName(loginViewModel.UserName);

            if (user == null)
            {
                return LoginResult.NotFound;
            }

            if (user.Password != PasswordHelper.EncodePasswordMd5(loginViewModel.Password))
            {
                return LoginResult.NotFound;
            }

            return LoginResult.Success;
        }

        public User GetUserByUserName(string userName)
        {
            return _userRepository.GetUserByUserName(userName);
        }

        public User GetUserByEmail(string email)
        {
            return _userRepository.GetUserByEmail(email);
        }

        public void UpdateUser(User user)
        {
            _userRepository.UpdateUser(user);
        }

        public CreateUserResult AddUserFromAdmin(CreateUserViewModel user)
        {
            if (_userRepository.IsExistUserName(user.UserName) == true)
            {
                return CreateUserResult.ExistUserName;
            }

            if (_userRepository.IsExistEmail(user.Email) == true)
            {
                return CreateUserResult.ExistEmail;
            }

            User addUser = new User()
            {
                Email = user.Email,
                UserName = user.UserName.ToLower(),
                Password = PasswordHelper.EncodePasswordMd5(user.Password),
                IsAdmin = true,
                CreateDate = DateTime.Now,
                FirstName = user.FirstName,
                LastName = user.LastName
            };

            #region Save Avatar

            if (user.UserAvatar != null)
            {
                if (ImageValidation.Validate(user.UserAvatar.FileName))
                {

                    string imagePath = "";
                    addUser.AvatarName = NameGenerator.GenerateUniqCode() + Path.GetExtension(user.UserAvatar.FileName);
                    imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/UserAvatar", addUser.AvatarName);
                    using (var stream = new FileStream(imagePath, FileMode.Create))
                    {
                        user.UserAvatar.CopyTo(stream);
                    }

                }
                else
                {
                    return CreateUserResult.InValidImage;
                }
            }
            else
            {
                addUser.AvatarName = "Default.jpg";
            }

            #endregion

            _userRepository.AddUser(addUser);

            return CreateUserResult.Success;
        }

        public EditUserViewModel GetUserForShowInEditMode(int userId)
        {
            var user = _userRepository.GetUserById(userId);
            EditUserViewModel editUser = new EditUserViewModel()
            {
                UserId = user.UserId,
                UserName = user.UserName,
                Email = user.Email,
                FirstName = user.FirstName,
                LastName = user.LastName,
                AvatarName = user.AvatarName
            };

            return editUser;
        }

        public EditUserResult EditUserFromAdmin(EditUserViewModel editUser)
        {
            User user = _userRepository.GetUserById(editUser.UserId);

            if (editUser.Email != user.Email)
            {
                if (_userRepository.IsExistEmail(editUser.Email))
                {
                    return EditUserResult.ExistEmail;
                }
            }

            if (editUser.UserName != user.UserName)
            {
                if (_userRepository.IsExistUserName(editUser.UserName))
                {
                    return EditUserResult.ExistUserName;
                }
            }

            user.Email = editUser.Email;
            user.UserName = editUser.UserName;
            if (!string.IsNullOrEmpty(editUser.Password))
            {
                user.Password = PasswordHelper.EncodePasswordMd5(editUser.Password);
            }

            #region ChangeImage

            if (editUser.UserAvatar != null)
            {
                if (ImageValidation.Validate(editUser.UserAvatar.FileName))
                {
                    //Delete Old Image
                    if (editUser.AvatarName != "Default.jpg")
                    {
                        string deletePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/UserAvatar", editUser.AvatarName);
                        if (File.Exists(deletePath))
                        {
                            File.Delete(deletePath);
                        }
                    }

                    //Save New Image
                    user.AvatarName = NameGenerator.GenerateUniqCode() + Path.GetExtension(editUser.UserAvatar.FileName);
                    string imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/UserAvatar", user.AvatarName);
                    using (var stream = new FileStream(imagePath, FileMode.Create))
                    {
                        editUser.UserAvatar.CopyTo(stream);
                    }
                }
                else
                {
                    return EditUserResult.InValidImage;
                }
            }

            #endregion

            _userRepository.UpdateUser(user);
            return EditUserResult.Success;
        }

        public InformationUserViewModel GetUserInformation(int userId)
        {
            var user = _userRepository.GetUserById(userId);
            InformationUserViewModel information = new InformationUserViewModel()
            {
                UserName = user.UserName,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                CreateDate = user.CreateDate,
                AvatarName = user.AvatarName
            };

            return information;
        }

        public UserForAdminViewModel GetUsers(int pageId = 1, string filterEmail = "", string filterUserName = "")
        {
            return _userRepository.GetUsers(pageId, filterEmail, filterUserName);
        }

        public DeleteUserResult DeleteUser(int userId)
        {
            var user = _userRepository.GetUserById(userId);
            user.IsDelete = true;
            user.AvatarName = "Default.jpg";

            #region DeleteImage

            if (user.AvatarName != "Default.jpg")
            {
                string deletePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/UserAvatar", user.AvatarName);
                if (File.Exists(deletePath))
                {
                    File.Delete(deletePath);
                }
            }

            #endregion


            UpdateUser(user);

            return DeleteUserResult.Success;

        }

        public int GetUserCount()
        {
            return _userRepository.GetUserCount();
        }
    }
}