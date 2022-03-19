using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMSApplication.Application.Dtos.Admin.UserServiceDtos.GetUserInfoDtos
{
    public class UserInfoDto
    {
        public string Id { get; set; }
        public bool IsActive { get; set; }
        public int PostCount { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string ProfileImage { get; set; }
        public string Role { get; set; }
    }
}
