using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Mqeb.Application.Interfaces;

namespace Mqeb.Web.ViewComponents
{
    public class CategoryComponent: ViewComponent
    {
        #region Constractor

        private IBlogService _blogService;
        public CategoryComponent(IBlogService blogService)
        {
            _blogService = blogService;
        }

        #endregion

        public async Task<IViewComponentResult> InvokeAsync()
        {
            return await Task.FromResult((IViewComponentResult)View("ShowCategory", _blogService.GetAllCategory()));
        }
    }
}
