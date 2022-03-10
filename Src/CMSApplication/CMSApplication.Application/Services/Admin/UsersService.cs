using CMSApplication.Application.Contracts.Admin;
using CMSApplication.Application.Dtos.Admin.UserServiceDtos.GetUserListDtos;
using CMSApplication.CommonTools;
using CMSApplication.CommonTools.Dtos;
using CMSApplication.Domain.Entities.MainEntities.UserEntities;
using CMSApplication.Persistance;
using CMSApplication.Persistance.Context;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMSApplication.Application.Services.Admin
{
    public class UsersService : IUsersService
    {

        private readonly ApplicationDbContext _context;
        private readonly UserManager<User> _userManager;

        public UsersService(ApplicationDbContext context, UserManager<User> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public GetUserListResultDto GetUserList(GetUserListRequestDto request)
        {
            var users = _context.Users
                                .Include(user => user.Role)
                                .Include(user => user.Articles)
                                .AsQueryable();
            
            if(!string.IsNullOrWhiteSpace(request.SearchKey))
            {
                users = users.Where(user => user.UserName.ToLower().Contains(request.SearchKey.ToLower()) || user.UserName.ToLower().Contains(request.SearchKey.ToLower()) || user.Role.Name.ToLower().Contains(request.SearchKey.ToLower()));
            }

            var userList = users.Paging(request.Page, request.PageSize, out int rowsCount)
                                .Select(user => new UserDto()
                                {
                                    Id = user.Id,
                                    Name = user.Name,
                                    Email = user.Email,
                                    IsActive = user.IsActive,
                                    PostCount = user.Articles.Count(),
                                    Role = user.Role.Name.ToString()
                                }).ToList();


            return new GetUserListResultDto()
            {
                RowsCount = rowsCount,
                Users = userList
            };
        }

        public async Task<ResultDto> ChangeActivity(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null) return new ResultDto() { IsSuccess = false, Message = "The User not Found." };

            user.IsActive = !user.IsActive;

            string userActivity = user.IsActive == true ? "Activated" : "Disabled";
            return new ResultDto()
            {
                IsSuccess = true,
                Message = $"User {userActivity} Successfuly."
            };
        }

        public async Task<ResultDto> DeleteUser(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null) return new ResultDto() { IsSuccess = false, Message = "User not Found." };


            var userRoles = await _userManager.GetRolesAsync(user);

            if(userRoles.Count() > 0)
            {
                foreach (var role in userRoles.ToList())
                {
                    await _userManager.RemoveFromRoleAsync(user, role);
                }
            }



            var actionResult = await _userManager.DeleteAsync(user);
            if (!actionResult.Succeeded)
            {
                return new ResultDto()
                {
                    IsSuccess = false,
                    Message = "Error Occured."
                };
            }
            return new ResultDto()
            {
                IsSuccess = true,
                Message = $"User : {user.Name} Deleted."
            };
        }

        public ResultDto EditUser(string userId, UserDto data)
        {
            throw new NotImplementedException();
        }


    }
}
