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
        GetCategoryListResultDto GetCategoryList(string? parentId);
        ResultDto Add(string name, string? parentId);
    }
}
