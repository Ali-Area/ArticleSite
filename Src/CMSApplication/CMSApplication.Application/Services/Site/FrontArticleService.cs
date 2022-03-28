using CMSApplication.Application.Contracts.Site;
using CMSApplication.Application.Dtos.Site.AddArticleDtos;
using CMSApplication.CommonTools;
using CMSApplication.CommonTools.Dtos;
using CMSApplication.CommonTools.UploadFile;
using CMSApplication.Domain.Entities.MainEntities.ArticleEntities;
using CMSApplication.Persistance.Context;
using Microsoft.AspNetCore.Hosting;
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


            var uploadImageResult = UploadFileManager.UploadImage(request.MainImage, _env);

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
                MainImage = uploadImageResult.Data.ImageAddress,
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
    }
}
