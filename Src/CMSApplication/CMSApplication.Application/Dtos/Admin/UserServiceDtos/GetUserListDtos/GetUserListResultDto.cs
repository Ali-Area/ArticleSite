using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMSApplication.Application.Dtos.Admin.UserServiceDtos.GetUserListDtos
{
    public class GetUserListResultDto
    {
        public int RowsCount { get; set; }
        public List<UserDto> Users { get; set; }

    }
}
