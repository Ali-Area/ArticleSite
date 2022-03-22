using CMSApplication.Application.Dtos.Admin.CategoryServiceDtos.GetCategoriesDto;

namespace CMSApplication.EndPoint.Areas.Admin.Models.ViewModels.CategoriesViewModels
{
    public class CategoryListViewModel
    {
        public List<CategoryDto> CategoryList { get; set; }
        public int Page { get; set; }
        public int PageSize { get; set; }
        public int RowsCount { get; set; }
        public string? SearchKey { get; set; }
    }
}
