using System.ComponentModel.DataAnnotations;

namespace CMSApplication.EndPoint.Models.SiteViewModels.RegisterViewModels
{
    public class SignInViewModel
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
        public bool IsPersistance { get; set; } = false;

    }
}
