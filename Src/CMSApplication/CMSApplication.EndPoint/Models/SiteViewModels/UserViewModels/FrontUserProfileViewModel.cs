using CMSApplication.Application.Dtos.Site.UserServiceDtos.GetProfileDetailsDto;

namespace CMSApplication.EndPoint.Models.SiteViewModels.UserViewModels
{
    public class FrontUserProfileViewModel
    {

        public UserProfileDetailDto ProfileInfo { get; set; }
        public List<ArticleDto> Articles { get; set; }

    }
}
