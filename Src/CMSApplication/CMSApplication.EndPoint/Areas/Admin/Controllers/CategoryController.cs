using CMSApplication.Application.Contracts.Admin;
using CMSApplication.EndPoint.Areas.Admin.Models.ViewModels.CategoriesViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

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


        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AddCategory()
        {
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
                var result =  _categoryService.Add(model.CategoryName, model.CategoryParent);

                if(result.IsSuccess == true)
                {
                    return RedirectToAction("Index", "Category");
                }
                return View(model);
            }
            return View(model);
        }

    }
}
