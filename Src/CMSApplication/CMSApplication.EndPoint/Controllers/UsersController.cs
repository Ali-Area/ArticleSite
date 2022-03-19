using CMSApplication.Domain.Entities.MainEntities.UserEntities;
using CMSApplication.EndPoint.Models.SiteViewModels.RegisterViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace CMSApplication.EndPoint.Controllers
{
    public class UsersController : Controller
    {

        private readonly UserManager<User> _userManager;
        private readonly RoleManager<Role> _roleManager;
        private readonly SignInManager<User> _signInManager;

        public UsersController(UserManager<User> userManager, RoleManager<Role> roleManager, SignInManager<User> signInManager)
        {
            this._userManager = userManager;
            this._roleManager = roleManager;
            this._signInManager = signInManager;
        }

        [HttpGet]
        public async Task<IActionResult> SignIn()
        {
            var model = new SignInViewModel();
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> SignIn(SignInViewModel model)
        {
            if (ModelState.IsValid)
            {
                var signInResult = await SignInTheUser(null, model.UserName, model.Password, model.IsPersistance);

                if(signInResult.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("Sign In", "Invalid Email or Password.");
                    return View(model);
                }
            }
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> SignUp()
        {
            var model = new SignUpViewModel();
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> SignUp(SignUpViewModel model)
        {

            if(ModelState.IsValid)
            {

                var result = await CreateUser(model);

                if(result.Succeeded)
                {
                    await AddClaimAndRole(model.Name, model.Email);

                    var signInResult = await SignInTheUser(model.Name, model.Email, model.Password);
                    
                    if(signInResult.Succeeded)
                    {
                        return RedirectToAction("Index", "Home");
                    }
                }
                else
                {
                    ModelState.AddModelError("Sign Up", String.Join(" - ", result.Errors.Select(e => e.Description).ToList()));
                    return View(model);
                }
            }

            return View(model);
        }


        public async Task<IActionResult> SignOut()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        public IActionResult AccessDenied()
        {
            return View();
        }














        // --- options methods --- //

        public async Task<IdentityResult> CreateUser(SignUpViewModel model)
        {

            if(await CheckUserNotExist(model.Email))
            {

                var role = await _roleManager.FindByIdAsync("user");

                var user = new User()
                {
                    UserName = model.Email,
                    Email = model.Email,
                    Name = model.Name,
                    Role = role,
                    RoleId = role.Id
                };


                var createUserResult = await _userManager.CreateAsync(user, model.Password);

                return createUserResult;

            }

            return IdentityResult.Failed(new IdentityError () { Code = "1", Description = "some error ocured."});
        }

        public async Task AddClaimAndRole(string name, string email)
        {
            var user = await _userManager.FindByEmailAsync(email);
            var role = await _roleManager.FindByNameAsync("User");

            var userNameClaim = new Claim("UserName", email);
            var emailClaim = new Claim("Email", email);
            var nameClaim = new Claim("Name", name);
            var roleClaim = new Claim("Role", user.Role.Name.ToString());
            
            await _userManager.AddClaimAsync(user, emailClaim);
            await _userManager.AddClaimAsync(user, userNameClaim);
            await _userManager.AddClaimAsync(user, nameClaim);
            await _userManager.AddClaimAsync(user, roleClaim);

            await _userManager.AddToRoleAsync(user, role.Name);

        }

        public async Task<Microsoft.AspNetCore.Identity.SignInResult> SignInTheUser(string? name, string email, string password, bool isPersistance = false)
        {
            var user = await _userManager.FindByEmailAsync(email);

            if(user == null)
            {
                return Microsoft.AspNetCore.Identity.SignInResult.Failed;
            }

            var signInResult = await _signInManager.PasswordSignInAsync(user, password, isPersistance, false);

            return signInResult;

        }

        public async Task<bool> CheckUserNotExist(string email)
        {
            if(await _userManager.FindByEmailAsync(email) == null)
            {
                return true;
            }
            return false;
        }


    }
}
