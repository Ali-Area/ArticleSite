using Microsoft.AspNetCore.Mvc;

namespace CMSApplication.EndPoint.Areas.Admin.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
