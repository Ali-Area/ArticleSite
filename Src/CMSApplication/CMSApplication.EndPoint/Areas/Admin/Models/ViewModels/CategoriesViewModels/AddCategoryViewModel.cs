using System.ComponentModel.DataAnnotations;

namespace CMSApplication.EndPoint.Areas.Admin.Models.ViewModels.CategoriesViewModels
{
    public class AddCategoryViewModel
    {
        [Required]
        [StringLength(20, MinimumLength = 3)]
        public string CategoryName { get; set; }
        public string? CategoryParent { get; set; }
    }
}
