using CMSApplication.Application.Contracts.Site;
using CMSApplication.Application.Dtos.Site.UserServiceDtos.EditProfileDto;
using CMSApplication.Application.Dtos.Site.UserServiceDtos.GetProfileDetailsDto;
using CMSApplication.CommonTools;
using CMSApplication.CommonTools.Dtos;
using CMSApplication.CommonTools.UploadFile;
using CMSApplication.Domain.Entities.MainEntities.UserEntities;
using CMSApplication.Persistance.Context;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace CMSApplication.Application.Services.Site
{
    public class FrontUserService : IFrontUserService
    {

        private readonly ApplicationDbContext _context;
        private readonly IHostingEnvironment _env;
        private readonly UserManager<User> _userManager;

        public FrontUserService(ApplicationDbContext context, IHostingEnvironment env, UserManager<User> userManager)
        {
            _context = context;
            _env = env;
            _userManager = userManager;
        }

        public ResultDto<UserProfileDetailDto> GetProfileDetails(GetProfileDetailsRequestDto request)
        {
            var user = _context.Users
                               .Include(user => user.Articles)
                               .Include(user => user.Role)
                               .Where(user => user.Id == request.UserId)
                               .FirstOrDefault();

            if (user == null)
            {
                return Tools.ReturnResult(false, "User not Found.", new UserProfileDetailDto() { });
            }



            var articles = _context.Articles
                               .Include(art => art.Author)
                               .Include(art => art.Comments)
                               .Include(art => art.Category)
                               .Where(art => art.AuthorId == user.Id)
                               .AsQueryable();

            if (!string.IsNullOrWhiteSpace(request.SearchKey))
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
                Biography = user.Biography,
                ProfileImage = user.ProfileImage,
                Articles = articleList,
                PaginationInfo = new PaginationInfo()
                {
                    Page = request.Page,
                    PageSize = request.PageSize,
                    SearchKey = request.SearchKey,
                    TotalCount = RowsCount
                }
            });


        }

        public async Task<ResultDto> EditProfile(EditProfileRequestDto request)
        {
            var user = _context.Users
                               .Find(request.UserId);

            if (user == null) { return Tools.ReturnResult(false, "User Not Found."); }


            // --- change profile image if user profile image is not null --- //
            if (request.ProfileImage != null)
            {
                var UploadResult = UploadFileManager.UploadImage(request.ProfileImage, _env, "ProfileImages");
                if (UploadResult.IsSuccess == false) { return Tools.ReturnResult(false, "Profile Image not Uploaded successfuly."); }
                user.ProfileImage = UploadResult.Data.Url;
            }


            // --- change biography if user biography is not null --- //
            if (request.Biography != null)
            {
                user.Biography = request.Biography;
            }


            return Tools.ReturnResult(true, "All thing Edited successfuly.");

        }

        public ResultDto<EditProfileDetailDto> GetEditProfileDetails(string userId)
        {
            var user = _context.Users.Find(userId);

            if (user == null)
            {
                return Tools.ReturnResult(false, "user not found.", new EditProfileDetailDto()
                {
                    Bioraphy = ""
                });
            }


            return Tools.ReturnResult(true, "", new EditProfileDetailDto()
            {
                Bioraphy = user.Biography
            });

        }






    }
}
