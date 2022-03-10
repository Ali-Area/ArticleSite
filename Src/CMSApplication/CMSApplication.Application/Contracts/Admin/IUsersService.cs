using CMSApplication.Application.Dtos.Admin.UserServiceDtos;
using CMSApplication.Application.Dtos.Admin.UserServiceDtos.GetUserListDtos;
using CMSApplication.CommonTools.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMSApplication.Application.Contracts.Admin
{
    public interface IUsersService
    {
        GetUserListResultDto GetUserList(GetUserListRequestDto request);
        Task<ResultDto> DeleteUser(string userId);
        Task<ResultDto> ChangeActivity(string userId);
        ResultDto EditUser(string userId, UserDto data);
    }
}
