using CMSApplication.Application.Contracts.Site;
using CMSApplication.Application.Dtos.Site.CategoryServiceDtos.GetAllChildCategoriesDto;
using CMSApplication.CommonTools;
using CMSApplication.CommonTools.Dtos;
using CMSApplication.Persistance.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMSApplication.Application.Services.Site
{
    public class FrontCategoryService : IFrontCategoryService
    {

        private readonly ApplicationDbContext _context;

        public FrontCategoryService(ApplicationDbContext context)
        {
            _context = context;
        }

        public ResultDto<List<ChildCategoryDto>> GetAllChildCategories()
        {
            var childCategoryies = _context.Categories
                                           .Include(cat => cat.ParentCategory)
                                           .Where(cat => cat.ParentCategoryId != null)
                                           .ToList();

            var childList = childCategoryies.Select(cat => new ChildCategoryDto()
            {
                Id = cat.Id,
                Name = cat.Name,
                ParentName = cat.ParentCategory.Name
            }).ToList();


            return Tools.ReturnResult(true, "", childList);
                               
        }
    }
}
