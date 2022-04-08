using CMSApplication.Application.Contracts.Site;
using CMSApplication.Application.Dtos.Site.ArticleDtos;
using CMSApplication.CommonTools.UploadFile;
using CMSApplication.EndPoint.Models.SiteViewModels.ArticleViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Net;

namespace CMSApplication.EndPoint.Controllers
{
    public class ArticleController : Controller
    {

        private readonly IFrontCategoryService _categoryService;
        private readonly IFrontArticleService _articleService;
        private readonly Microsoft.AspNetCore.Hosting.IHostingEnvironment _env;

        public ArticleController(IFrontCategoryService categoryService, IFrontArticleService articleService, Microsoft.AspNetCore.Hosting.IHostingEnvironment env)
        {
            this._categoryService = categoryService;
            this._articleService = articleService;
            this._env = env;
        }



        public IActionResult Index()
        {
            return View();
        }

        
        [HttpGet]
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


        public IActionResult DeleteArticle(string articleId)
        {
            var deleteResult = _articleService.DeleteArticle(articleId);
            return Json(deleteResult);
        }


        public IActionResult ShowArticleDetails(string articleId)
        {
            var data = _articleService.ShowArticleDetails(articleId);

            if(data.IsSuccess == false)
            {
                return RedirectToAction("Users", "Profile");
            }

            var model = new ShowArticleDetailsViewModel()
            {
                Id = data.Data.Id,
                Title = data.Data.Title,
                Author = data.Data.Author,
                Body = data.Data.Body,
                Category = data.Data.Category,
                CommentCount = data.Data.CommentCount,
                CreateDate = data.Data.CreateDate,
                MainImage = data.Data.MainImage,
                Visit = data.Data.Visit           
            };

            return View(model);
        }






        // --- other mehtods --- //

        [HttpPost]
        public IActionResult UploadCkEditorImage()
        {

            var files = Request.Form.Files;

            if (files.Count() <= 0)
            {
                return null;
            }

            var formImage = files[0];


            var uploadResult = UploadFileManager.UploadImage(formImage, _env, "ArticleImages\\InPostImages");


            var result = new
            {
                Uploaded = true,
                Url = "/" + uploadResult.Data.Url
            };

            return Json(result);
        }

    }
}
