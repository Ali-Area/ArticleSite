using CMSApplication.Application.Contracts.Site;
using CMSApplication.Application.Dtos.Site.UserServiceDtos.GetProfileDetailsDto;
using CMSApplication.CommonTools;
using CMSApplication.CommonTools.Dtos;
using CMSApplication.Persistance.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMSApplication.Application.Services.Site
{
    public class FrontUserService : IFrontUserService
    {

        private readonly ApplicationDbContext _context;

        public FrontUserService(ApplicationDbContext context)
        {
            _context = context;
        }

        public ResultDto<UserProfileDetailDto> GetProfileDetails(GetProfileDetailsRequestDto request)
        {
            var user = _context.Users
                               .Include(user => user.Articles)
                               .Include(user => user.Role)
                               .Where(user => user.Id == request.UserId)
                               .FirstOrDefault();

            if(user == null)
            {
                return Tools.ReturnResult(false, "User not Found.", new UserProfileDetailDto() { });
            }



            var articles = _context.Articles
                               .Include(art => art.Author)
                               .Include(art => art.Comments)
                               .Include(art => art.Category)
                               .Where(art => art.AuthorId == user.Id)
                               .AsQueryable();

            if(!string.IsNullOrWhiteSpace(request.SearchKey))
            {
                request.SearchKey.ToLower();
                articles = articles.Where(art => art.Title.ToLower().Contains(request.SearchKey) || art.Author.Name.ToLower().Contains(request.SearchKey) || art.Summary.ToLower().Contains(request.SearchKey) || art.Category.Name.ToLower().Contains(request.SearchKey));
            }


            var articleList = articles.Paging(request.Page, request.PageSize, out int RowsCount)
                                      .Select(article => new ArticleDto()
                                      {
                                          ArticleId = article.Id,
                                          AuthorName = article.Author.Name,
                                          Category = article.Category.Name,
                                          CommentsCount = article.CommentsCount,
                                          Created = article.CreateDate,
                                          IsSpecial = article.IsSpecial,
                                          MainImage = article.MainImage,
                                          Summary = article.Summary,
                                          Tags = "",
                                          Title = article.Title,
                                      }).ToList();


            return Tools.ReturnResult(true, "", new UserProfileDetailDto()
            {
                Name = user.Name,
                UserId = user.Id,
                UserName = user.UserName,
                Email = user.Email,
                PostCount = user.Articles.Count(),
                Role = user.Role.Name,
                ProfileImage = user.ProfileImage,
                Articles = articleList
            });


        }
    }
}
