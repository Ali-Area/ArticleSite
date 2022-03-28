using CMSApplication.Application.Contracts.Admin;
using CMSApplication.Application.Dtos.Admin.CategoryServiceDtos.GetCategoriesDto;
using CMSApplication.EndPoint.Areas.Admin.Models.ViewModels.CategoriesViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;


namespace CMSApplication.EndPoint.Areas.Admin.Controllers
{
    [Area("Admin")]

    public class CategoryController : Controller
    {

        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService service)
        {
            _categoryService = service;
        }


        public IActionResult Index(string? parentCatId, string? searchKey, int page = 1, int pageSize = 10)
        {
            var getListResult = _categoryService.GetCategoryList(new GetCategoryListRequestDto()
            {
                Page = page,
                PageSize = pageSize,
                ParentId = parentCatId,
                SearchKey = searchKey
            });

            var model = new CategoryListViewModel()
            {
                CategoryList = getListResult.CategoryList,
                Page = getListResult.Page,
                PageSize = getListResult.PageSize,
                RowsCount = getListResult.RowsCount,
                SearchKey = getListResult.SearchKey
            };
            return View(model);
        }

        public IActionResult AddCategory()
        {

            ViewBag.Categories = new SelectList(_categoryService.GetParentCategories().Data, "Id", "Name");

            var model = new AddCategoryViewModel()
            {
                  
            };
            return View(model);
            
        }

        [HttpPost]
        public IActionResult AddCategory(AddCategoryViewModel model)
        {
            if(ModelState.IsValid)
            {
                var result =  _categoryService.AddCategory(model.CategoryName, model.CategoryParent);

                if(result.IsSuccess == true)
                {
                    return RedirectToAction("Index", "Category");
                }
                ViewBag.Categories = new SelectList(_categoryService.GetParentCategories().Data, "Id", "Name");
                return View(model);
            }
            ViewBag.Categories = new SelectList(_categoryService.GetParentCategories().Data, "Id", "Name");
            return View(model);
        }

        public IActionResult DeleteCategory(string categoryId)
        {
            var result = _categoryService.DeleteCategory(categoryId);
            return Json(result);
        }

       

    }
}
