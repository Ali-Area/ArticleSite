using CMSApplication.Domain.Entities.MainEntities.UserEntities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CMSApplication.EndPoint.Controllers
{
    public class UsersController : Controller
    {

        private readonly UserManager<IdentityUser> _userManager;

        public UsersController(UserManager<IdentityUser> userManager)
        {
            this._userManager = userManager;
        }

        public async Task<IActionResult> SignIn()
        {


            return View();
        }


    }
}
