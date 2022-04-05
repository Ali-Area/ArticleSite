using CMSApplication.Application.Contracts.Site;
using CMSApplication.Application.Dtos.Site.UserServiceDtos.EditProfileDto;
using CMSApplication.Application.Dtos.Site.UserServiceDtos.GetProfileDetailsDto;
using CMSApplication.CommonTools;
using CMSApplication.Domain.Entities.MainEntities.UserEntities;
using CMSApplication.EndPoint.Areas.Admin.Models.ViewModels.UsersViewModels;
using CMSApplication.EndPoint.Models.SiteViewModels.RegisterViewModels;
using CMSApplication.EndPoint.Models.SiteViewModels.UserViewModels;
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
        private readonly IFrontUserService _userService;

        public UsersController(UserManager<User> userManager, RoleManager<Role> roleManager, SignInManager<User> signInManager, IFrontUserService userService)
        {
            this._userManager = userManager;
            this._roleManager = roleManager;
            this._signInManager = signInManager;
            this._userService = userService;
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

                if (signInResult.Succeeded)
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

            if (ModelState.IsValid)
            {

                var result = await CreateUser(model);

                if (result.Succeeded)
                {
                    await AddClaimAndRole(model.Name, model.Email);

                    var signInResult = await SignInTheUser(model.Name, model.Email, model.Password);

                    if (signInResult.Succeeded)
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


        public IActionResult Profile(string? searchKey, int page = 1)
        {

            var userid = User.Claims.FirstOrDefault(claim => claim.Type.Equals("UserId", StringComparison.OrdinalIgnoreCase))?.Value.ToString();
            var profileInfo = _userService.GetProfileDetails(new GetProfileDetailsRequestDto()
            {
                Page = page,
                PageSize = 2,
                SearchKey = searchKey,
                UserId = userid
            });

            if (profileInfo.IsSuccess == false)
            {
                return RedirectToAction("Index", "Home");
            }

            var model = new FrontUserProfileViewModel()
            {
                ProfileInfo = profileInfo.Data,
                Articles = profileInfo.Data.Articles
            };


            return View(model);




        }

        [HttpGet]
        public IActionResult EditProfile()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> EditProfile (FrontEditProfileViewModel model)
        {
            if(!ModelState.IsValid)
            {
                return View(model);
            }

            var userId = User.Claims.FirstOrDefault(claim => claim.Type.Equals("UserId", StringComparison.OrdinalIgnoreCase))?.Value.ToString();

            if(userId == null) { return Json(Tools.ReturnResult(false, "User Not Found.")); }


            var editResult = await _userService.EditProfile(new EditProfileRequestDto()
            {
                UserId = userId,
                Biography = model.Biography,
                Name = model.Name,
                ProfileImage = model.ProfileImage
            });

            if(editResult.IsSuccess == false) { return Json(Tools.ReturnResult(false, editResult.Message)); }

            return RedirectToAction("Profile", "Users");

        }










        // --- options methods --- //

        public async Task<IdentityResult> CreateUser(SignUpViewModel model)
        {

            if (await CheckUserNotExist(model.Email))
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

            return IdentityResult.Failed(new IdentityError() { Code = "1", Description = "some error ocured." });
        }

        public async Task AddClaimAndRole(string name, string email)
        {
            var user = await _userManager.FindByEmailAsync(email);
            var role = await _roleManager.FindByNameAsync("User");

            var userNameClaim = new Claim("UserName", email);
            var userIdClaim = new Claim("UserId", user.Id);
            var emailClaim = new Claim("Email", email);
            var nameClaim = new Claim("Name", name);
            var roleClaim = new Claim("Role", user.Role.Name.ToString());

            await _userManager.AddClaimAsync(user, emailClaim);
            await _userManager.AddClaimAsync(user, userNameClaim);
            await _userManager.AddClaimAsync(user, nameClaim);
            await _userManager.AddClaimAsync(user, roleClaim);
            await _userManager.AddClaimAsync(user, userIdClaim);

            await _userManager.AddToRoleAsync(user, role.Name);

        }

        public async Task<Microsoft.AspNetCore.Identity.SignInResult> SignInTheUser(string? name, string email, string password, bool isPersistance = false)
        {
            var user = await _userManager.FindByEmailAsync(email);

            if (user == null)
            {
                return Microsoft.AspNetCore.Identity.SignInResult.Failed;
            }

            var signInResult = await _signInManager.PasswordSignInAsync(user, password, isPersistance, false);

            return signInResult;

        }

        public async Task<bool> CheckUserNotExist(string email)
        {
            if (await _userManager.FindByEmailAsync(email) == null)
            {
                return true;
            }
            return false;
        }


    }
}
