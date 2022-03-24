using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMSApplication.Application.Dtos.Site.UserServiceDtos.GetProfileDetailsDto
{
    public class GetProfileDetailsRequestDto
    {
        public string UserId { get; set; }
        public string? SearchKey { get; set; }
        public int Page { get; set; }
        public int PageSize { get; set; }
    }
}
