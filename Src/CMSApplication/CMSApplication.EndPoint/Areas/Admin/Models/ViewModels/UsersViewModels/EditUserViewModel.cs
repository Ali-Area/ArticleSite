using System.ComponentModel.DataAnnotations;

namespace CMSApplication.EndPoint.Areas.Admin.Models.ViewModels.UsersViewModels
{
    public class EditUserViewModel
    {
        [Required]
        public string UserId { get; set; }
        [Required]
        public string UserName { get; set; }
    }
}
