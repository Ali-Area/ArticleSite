using CMSApplication.Application.Dtos.Site.UserServiceDtos.EditProfileDto;
using CMSApplication.Application.Dtos.Site.UserServiceDtos.GetProfileDetailsDto;
using CMSApplication.CommonTools.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMSApplication.Application.Contracts.Site
{
    public interface IFrontUserService
    {
        ResultDto<UserProfileDetailDto> GetProfileDetails (GetProfileDetailsRequestDto reqest);
        ResultDto EditProfile(EditProfileRequestDto request);
    }
}
