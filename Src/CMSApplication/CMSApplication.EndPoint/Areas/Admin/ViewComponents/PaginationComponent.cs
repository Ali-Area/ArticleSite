using CMSApplication.EndPoint.Areas.Admin.Models.ViewModels.ComponentsViewModels;
using Microsoft.AspNetCore.Mvc;

namespace CMSApplication.EndPoint.Areas.Admin.ViewComponents
{
    public class PaginationComponent : ViewComponent
    {
        public IViewComponentResult Invoke(int page, int pageSize, int totalCount, string searchKey)
        {
            var model = new PaginationViewModel()
            {
                Page = page,
                PageSize = pageSize,
                TotalCount = totalCount,
                SearchKey = searchKey
            };

            return View("PaginationComponent", model: model);
        }
    }
}
