using System.ComponentModel.DataAnnotations;

namespace CMSApplication.EndPoint.Models.SiteViewModels.UserViewModels
{
    public class FrontEditProfileViewModel
    {
        [StringLength(30, MinimumLength = 3)]
        public string? Name { get; set; }
        public IFormFile? ProfileImage { get; set; }
        [StringLength(250, MinimumLength = 50)]
        public string? Biography { get; set; }
    }
}
