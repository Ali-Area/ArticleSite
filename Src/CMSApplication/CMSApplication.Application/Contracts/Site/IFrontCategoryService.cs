using CMSApplication.Application.Dtos.Site.CategoryServiceDtos.GetAllChildCategoriesDto;
using CMSApplication.CommonTools.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMSApplication.Application.Contracts.Site
{
    public interface IFrontCategoryService
    {
        ResultDto<List<ChildCategoryDto>> GetAllChildCategories();
    }
}
