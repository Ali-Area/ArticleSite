using System.ComponentModel.DataAnnotations;

namespace CMSApplication.EndPoint.Models.SiteViewModels.UserViewModels
{
    public class FrontEditProfileViewModel
    {
        [Required]
        [StringLength(30, MinimumLength = 3)]
        public string Name { get; set; }
        [Required]
        public IFormFile ProfileImage { get; set; }
        [Required]
        [StringLength(250, MinimumLength = 50)]
        public string Biography { get; set; }
    }
}
