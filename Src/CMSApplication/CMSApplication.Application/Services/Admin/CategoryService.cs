using CMSApplication.Application.Contracts.Admin;
using CMSApplication.Application.Dtos.Admin.CategoryServiceDtos.GetCategoriesDto;
using CMSApplication.CommonTools.Dtos;
using CMSApplication.Domain.Entities.MainEntities.CategoryEntities;
using CMSApplication.Persistance.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMSApplication.Application.Services.Admin
{
    public class CategoryService : ICategoryService
    {

        private readonly ApplicationDbContext _context;

        public CategoryService(ApplicationDbContext context)
        {
            _context = context;
        }

        public ResultDto Add(string name, string? parentId)
        {
            var category = new Category()
            {
                Id = Guid.NewGuid().ToString(),
                Name = name,
                ParentCategory = _context.Categories.Find(parentId)
            };

            _context.Categories.Add(category);

            return new ResultDto()
            {
                IsSuccess = true,
                Message = "Category Created."
            };
        }

        public GetCategoryListResultDto GetCategoryList(string? parentId)
        {
            throw new NotImplementedException();
        }
    }
}
