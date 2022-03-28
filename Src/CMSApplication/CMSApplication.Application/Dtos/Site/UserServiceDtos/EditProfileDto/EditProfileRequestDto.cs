using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMSApplication.Application.Dtos.Site.UserServiceDtos.EditProfileDto
{
    public class EditProfileRequestDto
    {
        public string UserId { get; set; }
        public string Name { get; set; }
        public IFormFile? ProfileImage { get; set; }
        public string? Biography { get; set; }

    }
}
