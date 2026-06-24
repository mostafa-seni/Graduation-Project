using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using User.Domain.Entities;
using User.ServicesAbstract;
using User.shared.DTOS;


namespace User.Services.Services
{
    internal class UserService(UserManager<AppUser> userManager,
        IHttpContextAccessor httpContextAccesso,
      IMapper mapper) : IUserService
    {
        public Task<UserDetailsRespones> GetUserDetailsAsync()
        {
            var user = GetLoggedInUserAsync().Result;
            return Task.FromResult(mapper.Map<UserDetailsRespones>(user));
        }

        public Task UpdateUserDetailsAsync(UserUpdateRequest userUpdate)
        {
            var user = GetLoggedInUserAsync().Result;
            mapper.Map(userUpdate, user);
            var result = userManager.UpdateAsync(user).Result;
            if (!result.Succeeded)
            {
                throw new Exception("Failed to update user details");
            }
            return Task.CompletedTask;


        }

        private async Task<AppUser> GetLoggedInUserAsync()
        {
            var user = httpContextAccesso.HttpContext?.User;

            if (user == null || !user.Identity!.IsAuthenticated)
            {
                throw new UnauthorizedAccessException("User not authenticated");
            }

            var userId = user.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            if (string.IsNullOrEmpty(userId))
            {
                throw new UnauthorizedAccessException("User Id not found in token");
            }

            return await userManager.FindByIdAsync(userId)
                ?? throw new Exception("User not found");
        }

    }
}
