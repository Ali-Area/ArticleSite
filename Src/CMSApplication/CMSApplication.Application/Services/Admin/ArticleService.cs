using CMSApplication.Application.Contracts.Admin;
using CMSApplication.Application.Dtos.Admin.ArticleServiceDtos;
using CMSApplication.CommonTools;
using CMSApplication.CommonTools.Dtos;
using CMSApplication.Persistance.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMSApplication.Application.Services.Admin
{
    public class ArticleService : IArticleService
    {

        private readonly ApplicationDbContext _context;

        public ArticleService(ApplicationDbContext context)
        {
            _context = context;
        }

        public ResultDto ChangeBeingSpecial(string articleId)
        {
            var article = _context.Articles.Find(articleId);

            if(article == null)
            {
                return Tools.ReturnResult(false, "article not found.");
            }

            article.IsSpecial = !article.IsSpecial;

            var resultText = article.IsSpecial == true ? "The Article is Special" : "The Article is Not Special.";

            return Tools.ReturnResult(true, resultText);
        }

        public ResultDto DeleteArticle(string articleId)
        {
            var article = _context.Articles.Find(articleId);
            
            if(article == null)
            {
                return Tools.ReturnResult(false, "article not found."); 
                    
            }

            article.IsDeleted = true;
            article.DeleteDate = DateTime.Now;

            return Tools.ReturnResult(true, "article removed.");

        }

        public GetArticleListResultDto GetArticleList(GetArticleListRequestDto request)
        {
            var articles = _context.Articles
                                   .Include(article => article.Author)
                                   .Include(article => article.Category)
                                   .AsQueryable();


            if(!string.IsNullOrWhiteSpace(request.SearchKey))
            {
                articles = articles.Where(article => article.Title.ToLower().Contains(request.SearchKey.ToLower()) || article.Category.Name.ToLower().Contains(request.SearchKey.ToLower()) || article.Author.Name.ToLower().Contains
                (request.SearchKey.ToLower()));
            }

            var articlesList = articles.Paging(request.Page, request.PageSize, out int rowCount)
                                       .Select(article => new ArticleInfoDto()
                                       {
                                           Author = article.Author.Name,
                                           Category = article.Category.Name,
                                           CommentCount = article.CommentsCount,
                                           Id = article.Id,
                                           IsSpecial = article.IsSpecial,
                                           MainImage = article.MainImage,
                                           Title = article.Title,
                                           Visit = article.Visite
                                       }).ToList();

            return new GetArticleListResultDto()
            {
                Page = request.Page,
                ArticleList = articlesList,
                PageSize = request.PageSize,
                SearchKey = request.SearchKey,
                RowsCount = rowCount
            };
        }
    }
}
