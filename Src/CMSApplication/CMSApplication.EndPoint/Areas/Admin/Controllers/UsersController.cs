using CMSApplication.Application.Contracts.Admin;
using CMSApplication.Application.Dtos.Admin.UserServiceDtos.GetUserListDtos;
using CMSApplication.Domain.Entities.MainEntities.UserEntities;
using CMSApplication.EndPoint.Areas.Admin.Models.ViewModels.UsersViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace CMSApplication.EndPoint.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UsersController : Controller
    {

        private readonly UserManager<User> _userManager;
        private readonly RoleManager<Role> _roleManager;
        private readonly IUsersService _userService;

        public UsersController(UserManager<User> userManager, RoleManager<Role> roleManager, IUsersService usersServicxe)
        {
            this._userManager = userManager;
            this._roleManager = roleManager;
            this._userService = usersServicxe;
        }

        public IActionResult Index(string? searchKey, int pageSize = 5, int page = 1)
        {

            var model = new UsersListViewModel()
            {
                Data = _userService.GetUserList(new GetUserListRequestDto()
                {
                    Page = page,
                    PageSize = pageSize,
                    SearchKey = searchKey
                })
            };
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> AddUser()
        {
            var model = new AddUserViewModel()
            {

            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> AddUser(AddUserViewModel model)
        {

            if (ModelState.IsValid)
            {
                var createUserResult = await CreateUser(model);
                if (createUserResult.Succeeded)
                {
                    await AddClaimsAndRole(model);
                    return RedirectToAction("Index", "Users");
                }
                else
                {
                    ModelState.AddModelError("Add User", String.Join(" - ", createUserResult.Errors.Select(e => e.Description).ToList()));
                    return View();
                }

            }

            return View(model);
        }

        public async Task<IActionResult> UserProfile(string userId)
        {
            var result = _userService.GetUserInfo(userId);
            if (result.IsSuccess == true)
            {
                var model = new UserProfileViewModel()
                {
                    UserInfo = result.Data
                };

                return View(model);

            }
            return View();
        }

        [HttpPost]
        public IActionResult DeleteUser(string userId)
        {
            var actionResult = _userService.DeleteUser(userId);
            return Json(actionResult);
        }

        [HttpPost]
        public IActionResult ChangeUserActivity(string userId)
        {
            var actionResult = _userService.ChangeActivity(userId);

            return Json(actionResult);
        }

        [HttpPost]
        public IActionResult EditUser(EditUserViewModel editUserViewModel)
        {
            if (ModelState.IsValid)
            {
                var actionResult = _userService.EditUser(editUserViewModel.UserId, editUserViewModel.UserName);
                return Json(actionResult);

            }
            return RedirectToAction("Index", "Users");
        }







        // --- methods --- //

        public async Task<bool> CheckUserNotExist(string email)
        {
            return await _userManager.FindByEmailAsync(email) == null;
        }

        public async Task<IdentityResult> CreateUser(AddUserViewModel model)
        {
            if (await CheckUserNotExist(model.Email))
            {

                var role = await _roleManager.FindByNameAsync(model.Role);

                var user = new User()
                {
                    Name = model.Name,
                    Email = model.Email,
                    UserName = model.Email,
                    Role = role,
                    RoleId = role.Id
                };

                var createUserResult = await _userManager.CreateAsync(user, model.Password);



                return createUserResult;

            }

            return IdentityResult.Failed(new IdentityError() { Code = "1", Description = "a User with the Entered Email is Exists in the DataBase." });
        }

        public async Task AddClaimsAndRole(AddUserViewModel model)
        {
            var user = await _userManager.FindByEmailAsync(model.Email);
            var role = await _roleManager.FindByIdAsync(model.Role.ToLower());

            var userNameClaim = new Claim("UserName", model.Email);
            var emailClaim = new Claim("Email", model.Email);
            var roleClaim = new Claim("Role", model.Role.ToString());
            var nameClaim = new Claim("Name", model.Name);

            await _userManager.AddClaimAsync(user, nameClaim);
            await _userManager.AddClaimAsync(user, userNameClaim);
            await _userManager.AddClaimAsync(user, emailClaim);
            await _userManager.AddClaimAsync(user, roleClaim);

            await _userManager.AddToRoleAsync(user, role.Name);


        }


    }
}
