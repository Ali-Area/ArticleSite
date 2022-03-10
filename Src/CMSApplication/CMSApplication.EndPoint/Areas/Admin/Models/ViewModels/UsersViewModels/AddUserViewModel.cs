using System.ComponentModel.DataAnnotations;

namespace CMSApplication.EndPoint.Areas.Admin.Models.ViewModels.UsersViewModels
{
    public class AddUserViewModel
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
        [Required]
        public string Role { get; set; }

    }
}
