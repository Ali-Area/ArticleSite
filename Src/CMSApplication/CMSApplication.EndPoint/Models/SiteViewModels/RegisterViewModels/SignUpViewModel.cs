using System.ComponentModel.DataAnnotations;

namespace CMSApplication.EndPoint.Models.SiteViewModels.RegisterViewModels
{
    public class SignUpViewModel
    {
        [Required]
        public string Name { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }

    }
}
