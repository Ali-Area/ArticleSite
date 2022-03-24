using Microsoft.AspNetCore.Mvc;

namespace CMSApplication.EndPoint.Controllers
{
    public class ArticleController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
