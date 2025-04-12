using System.Collections.Generic;
using System.Linq;
using Mqeb.Domain.Interfaces;
using Mqeb.Domain.Models.Account;
using Mqeb.Domain.ViewModels.Account;
using Mqeb.Infra.Data.Context;

namespace Mqeb.Infra.Data.Repositories
{
    public class UserRepository:IUserRepository
    {
        #region Constractor

        private MqebContext _context;

        public UserRepository(MqebContext context)
        {
            _context = context;
        }

        #endregion

        public User GetUserByUserName(string userName)
        {
            return _context.Users.SingleOrDefault(u => u.UserName == userName);
        }

        public User GetUserByEmail(string email)
        {
            return _context.Users.SingleOrDefault(u => u.Email == email);
        }

        public void UpdateUser(User user)
        {
            _context.Update(user);
            _context.SaveChanges();
        }

        public void AddUser(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
        }

        public bool IsExistUserName(string userName)
        {
            return _context.Users.Any(u => u.UserName == userName);
        }

        public bool IsExistEmail(string email)
        {
            return _context.Users.Any(u => u.Email == email);
        }

        public User GetUserById(int userId)
        {
            return _context.Users.Find(userId);
        }

        public UserForAdminViewModel GetUsers(int pageId = 1, string filterEmail = "", string filterUserName = "")
        {
            IQueryable<User> result = _context.Users;

            if (!string.IsNullOrEmpty(filterEmail))
            {
                result = result.Where(u => u.Email.Contains(filterEmail));
            }

            if (!string.IsNullOrEmpty(filterUserName))
            {
                result = result.Where(u => u.UserName.Contains(filterUserName));
            }

            //Show Item In Page
            int take = 10;
            int skip = (pageId - 1) * take;
            int pageCount = result.Count(b => !b.IsDelete) / take;

            if ((pageCount % 2) != 0)
            {
                pageCount += 1;
            }

            UserForAdminViewModel list = new UserForAdminViewModel();
            list.CurrentPage = pageId;
            list.PageCount = pageCount;
            list.Users = result.OrderBy(u => u.CreateDate).Skip(skip).Take(take).ToList();

            return list;
        }

        public int GetUserCount()
        {
            return _context.Users.Count();
        }
    }
}