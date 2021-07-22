using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FieldMgt.Core;
using FieldMgt.Core.Interfaces;
using FieldMgt.Core.DomainModels;
using Microsoft.AspNetCore.Identity;
using FieldMgt.Core.DTOs;
using FieldMgt.Core.DTOs.Response;
using System.Threading;
using FieldMgt.Repository.Enums;

namespace FieldMgt.Repository.Repository
{
    public class RoleRepository : IRoleRepository
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly ApplicationDbContext _dbContext;
        private readonly UserManager<ApplicationUser> _userManager;
        public RoleRepository(RoleManager<IdentityRole> roleManager, ApplicationDbContext dbcontext, UserManager<ApplicationUser> userManager)
        {
            _roleManager = roleManager;
            _dbContext = dbcontext;
            _userManager = userManager;
        }
        public RoleRepository(ApplicationDbContext dbcontext)
        {
            _dbContext = dbcontext;
        }
        /// <summary>
        /// Add new Role in database table
        /// </summary>
        /// <paramtype="string"></paramtype>
        /// <paramname ="role"></param>
        /// <returns></returns>
        public async Task<UserManagerReponse> AddRoleAsync(string role)
        {
            IdentityRole userRole = new IdentityRole(role);
            var result = await _roleManager.CreateAsync(userRole);
            if (result.Succeeded)
            {
                return new UserManagerReponse
                {
                    Message = ResponseMessages.RoleCreated,
                    IsSuccess = true
                };
            }
            return new UserManagerReponse
            {
                Message = ResponseMessages.RoleNotCreated,
                IsSuccess = false,
                Errors = result.Errors.Select(e => e.Description)
            };
        }
        /// <summary>
        /// Displays the list of roles from database table
        /// </summary>
        /// <paramname=""></param>
        /// <returns></returns>
        public IEnumerable<string> ListRoles()
        {
            var roles = _dbContext.Roles.ToList();
            foreach (var role in roles)
            {
                yield return role.Name;
            }
        }
        /// <summary>
        /// Assigns a role to the user
        /// </summary>
        /// <paramname="userName"></paramname>
        /// <paramname="role"></paramname>
        /// <returns></returns>
        public async Task<UserManagerReponse> EditUserRoles(string userName, string role)
        {
            var user = _userManager.Users.FirstOrDefault(x => x.UserName == userName);
            var roles = await _roleManager.FindByNameAsync(role);
            if (roles == null)
            {
                return new UserManagerReponse
                {
                    Message = ResponseMessages.RoleNotExit,
                };
            }
            else
            {
                var result = await _userManager.AddToRoleAsync(user, roles.Name);
                return new UserManagerReponse
                {
                    Message = result.ToString()
                };
            }
        }
        /// <summary>
        /// Removes user from a role
        /// </summary>
        /// <paramname="userName"></paramname>
        /// <paramname="role"></paramname>
        /// <returns></returns>
        public async Task<UserManagerReponse> RemoveUserRoles(string userName, string role)
        {
            var user = _userManager.Users.FirstOrDefault(x => x.UserName == userName);
            var roles = await _roleManager.FindByNameAsync(role);
            if (roles == null)
            {
                return new UserManagerReponse
                {
                    Message = ResponseMessages.RoleNotExit,
                    IsSuccess = false
                };
            }
            else
            {
                var result = await _userManager.RemoveFromRoleAsync(user, roles.Name);
                return new UserManagerReponse
                {
                    Message = result.ToString(),
                    IsSuccess = true
                };
            }
        }
    }
}
