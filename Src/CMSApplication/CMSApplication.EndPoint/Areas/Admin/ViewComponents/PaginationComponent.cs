using CMSApplication.EndPoint.Areas.Admin.Models.ViewModels.ComponentsViewModels;
using Microsoft.AspNetCore.Mvc;

namespace CMSApplication.EndPoint.Areas.Admin.ViewComponents
{
    public class PaginationComponent : ViewComponent
    {
        public IViewComponentResult Invoke(PaginationComponentRequestDto request)
        {
            var model = new PaginationViewModel()
            {
                Page = request.Page,
                PageSize = request.PageSize,
                TotalCount = request.TotalCount,
                SearchKey = request.SearchKey,
                Controller = request.Controller,
                Action = request.Action
            };

            return View("PaginationComponent", model: model);
        }
    }

}
