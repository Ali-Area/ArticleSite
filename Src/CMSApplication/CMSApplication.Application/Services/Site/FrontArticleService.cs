using CMSApplication.Application.Contracts.Site;
using CMSApplication.Application.Dtos.Site.ArticleDtos;
using CMSApplication.CommonTools;
using CMSApplication.CommonTools.Dtos;
using CMSApplication.CommonTools.UploadFile;
using CMSApplication.Domain.Entities.MainEntities.ArticleEntities;
using CMSApplication.Persistance.Context;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMSApplication.Application.Services.Site
{
    public class FrontArticleService : IFrontArticleService
    {

        private readonly ApplicationDbContext _context;
        private readonly IHostingEnvironment _env; 

        public FrontArticleService(ApplicationDbContext context, IHostingEnvironment env)
        {
            _context = context;
            _env = env;
        }


        public ResultDto AddArticle(AddArticleDto request)
        {
            var user = _context.Users.Find(request.AuthorId);

            var category = _context.Categories.Find(request.CategoryId);

            if (user == null) return Tools.ReturnResult(false, "User not Found.");
            if (category == null) return Tools.ReturnResult(false, "Category not Found.");


            var uploadImageResult = UploadFileManager.UploadImage(request.MainImage, _env, "ArticleImages");

            if (uploadImageResult.IsSuccess == false) return Tools.ReturnResult(false, "Image Not Uploaded.");

            var article = new Article()
            {
                Id = Guid.NewGuid().ToString(),
                Title = request.Title,
                Body = request.MainContent,
                AuthorId = user.Id,
                Author = user,
                Category = category,
                CategoryId = category.Id,
                IsSpecial = false,
                Summary = request.Summary,
                MainImage = uploadImageResult.Data.Url,
                CreateDate = DateTime.Now,
                IsDeleted = false,
                CommentsCount = 0,
                Visite = 0
            };

            _context.Articles.Add(article);

            return new ResultDto()
            {
                IsSuccess = true
            };
        }

        public ResultDto DeleteArticle(string articleId)
        {
            var article = _context.Articles.Find(articleId);

            if (article == null) { return Tools.ReturnResult(false, "article with this id not found."); }

            _context.Articles.Remove(article);

            return Tools.ReturnResult(true, "article removed.");
        }

        public ResultDto EditArticle(EditArticleDto request)
        {
            throw new NotImplementedException();
        }

        public ResultDto<ShowArticleDetailsDto> ShowArticleDetails(string articleId)
        {
            var article = _context.Articles
                                  .Include(article => article.Category)
                                  .Include(article => article.Author)
                                  .Include(article => article.Comments)
                                  .Where(article => article.Id == articleId)
                                  .FirstOrDefault();

            if(article == null)
            {
                return Tools.ReturnResult(false, "article not found.", new ShowArticleDetailsDto()
                {

                });
            }

            var articleDetails = new ShowArticleDetailsDto()
            {
                Id = article.Id,
                Author = article.Author.Name,
                Body = article.Body,
                Category = article.Category.Name,
                CreateDate = article.CreateDate.ToString(),
                CommentCount = article.CommentsCount,
                MainImage = article.MainImage,
                Title = article.Title,
                Visit = article.Visite
            };

            article.Visite += 1;
            _context.SaveChanges();

            return Tools.ReturnResult(true, "", articleDetails);

        }
    }
}
