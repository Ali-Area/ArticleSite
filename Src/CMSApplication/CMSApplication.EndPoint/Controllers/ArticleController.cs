using CMSApplication.Application.Contracts.Site;
using CMSApplication.Application.Dtos.Site.AddArticleDtos;
using CMSApplication.EndPoint.Models.SiteViewModels.ArticleViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CMSApplication.EndPoint.Controllers
{
    public class ArticleController : Controller
    {

        private readonly IFrontCategoryService _categoryService;
        private readonly IFrontArticleService _articleService;

        public ArticleController(IFrontCategoryService categoryService, IFrontArticleService articleService)
        {
            this._categoryService = categoryService;
            this._articleService = articleService;
        }



        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AddArticle()
        {
            var model = new AddArticleViewModel()
            {

            };

            var categories = _categoryService.GetAllChildCategories().Data;

            ViewBag.categories = new SelectList(categories, "Id", "Name");

            return View(model);
        }

        [HttpPost]
        public IActionResult AddArticle(AddArticleViewModel model)
        {
            var userId = User.Claims?.FirstOrDefault(claim => claim.Type.Equals("UserId"))?.Value.ToString();

            var categories = _categoryService.GetAllChildCategories().Data;

            if (userId == null)
            {

                ViewBag.categories = new SelectList(categories, "Id", "Name");

                return View(model);
            }

            if (ModelState.IsValid == false)
            {
                ViewBag.categories = new SelectList(categories, "Id", "Name");


                return View(model);
            }

            var addResult = _articleService.AddArticle(new AddArticleDto()
            {
                AuthorId = userId,
                CategoryId = model.ArticleInof.Category,
                MainContent = model.ArticleInof.Body,
                MainImage = model.ArticleInof.MainImage,
                Summary = model.ArticleInof.Summary,
                Title = model.ArticleInof.Title
            });

            if (addResult.IsSuccess == true)
            {
                return RedirectToAction("Profile", "Users");
            }

            ViewBag.categories = new SelectList(categories, "Id", "Name");

            return View(model);
        }

    }
}
