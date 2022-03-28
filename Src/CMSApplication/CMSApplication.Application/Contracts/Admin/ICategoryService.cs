using CMSApplication.Application.Dtos.Admin.CategoryServiceDtos.GetCategoriesDto;
using CMSApplication.CommonTools.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMSApplication.Application.Contracts.Admin
{
    public interface ICategoryService
    {
        GetCategoryListResultDto GetCategoryList(GetCategoryListRequestDto request);
        ResultDto AddCategory(string name, string? parentId);
        ResultDto<List<ParentCategoryDto>> GetParentCategories();
        ResultDto DeleteCategory(string categoryId);
    }
}
