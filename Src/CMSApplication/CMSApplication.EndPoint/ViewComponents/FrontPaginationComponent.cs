
using CMSApplication.EndPoint.Models.SiteViewModels.PaginationViewModel;
using Microsoft.AspNetCore.Mvc;

namespace CMSApplication.EndPoint.ViewComponents
{
    public class FrontPaginationComponent : ViewComponent
    {
        public IViewComponentResult Invoke(FrontPaginationComponentRequestDto request)
        {
            var model = new FrontPaginationViewModel()
            {
                Page = request.Page,
                PageSize = request.PageSize,
                TotalCount = request.TotalCount,
                SearchKey = request.SearchKey,
                Controller = request.Controller,
                Action = request.Action
            };

            return View("FrontPaginationComponent", model: model);
        }
    }

}
