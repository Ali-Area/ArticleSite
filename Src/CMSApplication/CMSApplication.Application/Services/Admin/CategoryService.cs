using CMSApplication.Application.Contracts.Admin;
using CMSApplication.Application.Dtos.Admin.CategoryServiceDtos.GetCategoriesDto;
using CMSApplication.CommonTools;
using CMSApplication.CommonTools.Dtos;
using CMSApplication.Domain.Entities.MainEntities.CategoryEntities;
using CMSApplication.Persistance.Context;
using Microsoft.EntityFrameworkCore;
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

            return Tools.ReturnResult(true, $"Category : {category.Name} created.");
        }

        public ResultDto DeleteCategory(string categoryId)
        {
            var category = _context.Categories
                                   .Include(cat => cat.Childs)
                                   .Where(cat => cat.Id == categoryId)
                                   .FirstOrDefault();
            if (category == null)
            {
                return Tools.ReturnResult(false, "Category Not Found.");
            }


            if (category.Childs.Count() > 0)
            {
                var subCategories = _context.Categories
                                            .Include(cat => cat.Childs)
                                            .Where(cat => cat.ParentCategoryId == category.Id)
                                            .ToList();

                foreach (var cat in subCategories)
                {
                    cat.IsDeleted = true;
                    cat.DeleteDate = DateTime.Now;
                }

            }


            category.IsDeleted = true;
            category.DeleteDate = DateTime.Now;




            return Tools.ReturnResult(true, $"Category : {category.Name} Deleted.");

        }

        public GetCategoryListResultDto GetCategoryList(GetCategoryListRequestDto request)
        {
            var categories = _context.Categories
                                     .Include(cat => cat.ParentCategory)
                                     .Include(cat => cat.Childs)
                                     .Include(cat => cat.Articles)
                                     .Where(cat => cat.ParentCategoryId == request.ParentId)
                                     .AsQueryable();

            if (!string.IsNullOrWhiteSpace(request.SearchKey))
            {
                categories = categories.Where(cat => cat.Name.ToLower().Contains(request.SearchKey.ToLower()));
            };



            var CategoryList = categories.Paging(request.Page, request.PageSize, out int rowCount)
                      .Select(cat => new CategoryDto()
                      {
                          Id = cat.Id,
                          Name = cat.Name,
                          HasChild = cat.Childs.Count() > 0 ? true : false,
                          Parent = cat.ParentCategory == null ? null : new ParentCategoryDto()
                          {
                              Id = cat.ParentCategory.Id,
                              Name = cat.ParentCategory.Name
                          },
                          SubCount = cat.Childs.Count(),
                          PostCount = cat.Articles.Count()
                      }).ToList();


            return new GetCategoryListResultDto()
            {
                CategoryList = CategoryList,
                Page = request.Page,
                PageSize = request.PageSize,
                RowsCount = rowCount,
                SearchKey = request.SearchKey
            };
        }

        public ResultDto<List<ParentCategoryDto>> GetParentCategories()
        {
            var categories = _context.Categories
                                     .Include(cat => cat.ParentCategory)
                                     .Where(cat => cat.ParentCategoryId == null)
                                     .Select(cat => new ParentCategoryDto()
                                     {
                                         Id = cat.Id,
                                         Name = cat.Name
                                     }).ToList();


            return Tools.ReturnResult(true, "", categories);

        }


    }
}
