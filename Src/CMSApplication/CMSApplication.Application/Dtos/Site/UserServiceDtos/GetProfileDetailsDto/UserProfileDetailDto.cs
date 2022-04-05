using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMSApplication.Application.Dtos.Site.UserServiceDtos.GetProfileDetailsDto
{
    public class UserProfileDetailDto
    {
        public string UserId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string? Biography { get; set; }
        public string UserName { get; set; }
        public string Role { get; set; }
        public int PostCount { get; set; } = 0;
        public string ProfileImage { get; set; }
        public List<ArticleDto> Articles { get; set; }
        public PaginationInfo PaginationInfo { get; set; }
    }


    public class PaginationInfo{
        public int TotalCount { get; set; }
        public int PageSize { get; set; }
        public int Page { get; set; }
        public string SearchKey { get; set; }

    }

}
