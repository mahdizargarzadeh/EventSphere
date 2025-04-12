using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using Mqeb.Domain.Interfaces;
using Mqeb.Domain.Models.Home;
using Mqeb.Domain.ViewModels.Banner;
using Mqeb.Domain.ViewModels.Blog;
using Mqeb.Domain.ViewModels.Home;
using Mqeb.Infra.Data.Context;

namespace Mqeb.Infra.Data.Repositories
{
    public class HomeRepository : IHomeRepository
    {
        #region Constractor

        private MqebContext _context;

        public HomeRepository(MqebContext context)
        {
            _context = context;
        }

        #endregion

        public void AddContactUsForm(ContactUs contactUs)
        {
            _context.ContactUses.Add(contactUs);
            _context.SaveChanges();
        }

        public void AddNewsLetter(string email)
        {
            _context.NewsLetters.Add(new NewsLetter()
            {
                Email = email
            });
            _context.SaveChanges();
        }

        public List<NewsLetter> GetNewsLetter()
        {
            return _context.NewsLetters.ToList();
        }

        public bool EditAboutUs(string description)
        {
            var aboutUs = _context.AboutUses.SingleOrDefault(a => a.AboutUsId == 1);

            if (aboutUs != null)
            {
                aboutUs.AboutDescription = description;
                _context.AboutUses.Update(aboutUs);
                _context.SaveChanges();
                return true;
            }

            return false;
        }

        public AboutUs GetAboutUs()
        {
            return _context.AboutUses.SingleOrDefault(a => a.AboutUsId == 1);
        }

        public void DeleteBanner(int bannerId)
        {
            var banner = _context.Banners.Find(bannerId);
            banner.IsDelete = true;
            _context.Banners.Update(banner);
            _context.SaveChanges();
        }

        public List<Banner> GetAllBanners()
        {
            return _context.Banners.ToList();
        }

        public ContactUsForAdminViewModel GetContactUses(int pageId = 1, string filterTitle = "")
        {
            IQueryable<ContactUs> result = _context.ContactUses;

            if (!string.IsNullOrEmpty(filterTitle))
            {
                result = result.Where(u => u.Title.Contains(filterTitle));
            }

            //Show Item In Page
            int take = 10;
            int skip = (pageId - 1) * take;

            ContactUsForAdminViewModel list = new ContactUsForAdminViewModel();
            list.CurrentPage = pageId;
            list.PageCount = result.Count() / take;
            list.ContactUses = result.OrderByDescending(u => u.CreateDate).Skip(skip).Take(take).ToList();

            return list;
        }

        public ContactUs GetContactUsMessageById(int contactUsId)
        {
            return _context.ContactUses.Find(contactUsId);
        }

        public void TrueIsAnswerContactUs(int contactUsId)
        {
            var contactUs = GetContactUsMessageById(contactUsId);
            contactUs.IsAnswer = true;
            _context.ContactUses.Update(contactUs);
            _context.SaveChanges();
        }

        public void AddBanner(Banner banner)
        {
            _context.Banners.Add(banner);
            _context.SaveChanges();
        }

        public List<ShowBannerViewModel> GetBannersForShow()
        {
            return _context.Banners
                .Select(b => new ShowBannerViewModel()
                {
                    BannerImageName = b.BannerImageName,
                    BannerLink = b.BannerLink
                }).ToList();
        }

        public Banner GetBannerById(int bannerId)
        {
            return _context.Banners.Find(bannerId);
        }

        public int GetBannerCount()
        {
            return _context.Banners.Count();
        }
    }
}