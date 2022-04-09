using CMSApplication.Application.Contracts.Admin;
using CMSApplication.Application.Dtos.Admin.ArticleServiceDtos;
using CMSApplication.EndPoint.Areas.Admin.Models.ViewModels.ArticleViewModels;
using Microsoft.AspNetCore.Mvc;

namespace CMSApplication.EndPoint.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ArticleController : Controller
    {

        private readonly IArticleService _articleService;
        public ArticleController(IArticleService articleService)
        {
            _articleService = articleService;
        }


        public IActionResult Index(string? searchKey, int page = 1, int pageSize = 2)
        {

            var articles = _articleService.GetArticleList(new GetArticleListRequestDto()
            {
                Page = page,
                PageSize = pageSize,
                SearchKey = searchKey,
            });

            var model = new ArticleListViewModel()
            {
                Data = articles
            };
            return View(model);
        }

        public IActionResult DeleteArticle(string articleId)
        {
            var result = _articleService.DeleteArticle(articleId);
            return Json(result);
        }

        public IActionResult ChangeBeingSpecial(string articleId)
        {
            var result = _articleService.ChangeBeingSpecial(articleId);
            return Json(result);
        }

    }
}
