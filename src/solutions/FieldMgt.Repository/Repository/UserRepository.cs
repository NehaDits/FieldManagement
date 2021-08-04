using FieldMgt.Core.DomainModels;
using FieldMgt.Core.DTOs.Request;
using FieldMgt.Core.DTOs.Response;
using FieldMgt.Core.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using FieldMgt.Repository.Enums;
using System.Net;

namespace FieldMgt.Repository.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly UserManager<ApplicationUser> _userManager;

        private IConfiguration _configuration;
        private ApplicationDbContext _dbContext;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userManager"></param>
        /// <param name="dbcontext"></param>
        /// <param name="configuration"></param>
        public UserRepository(UserManager<ApplicationUser> userManager, ApplicationDbContext dbcontext, IConfiguration configuration)
        {
            _userManager = userManager;
            _configuration = configuration;
            _dbContext = dbcontext;
        }

        /// <summary>
        /// Create a User with given UserName and Password
        /// To use for user registeration
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<string> RegisterUserAsync(CreateEmployeeDTO model)
        {
            try
            {
                var identityUser = new ApplicationUser
                {
                    Email = model.Email,
                    UserName = model.Email,
                    CreatedBy = model.CreatedBy,
                    CreatedOn = model.CreatedOn,
                    IsActive = true,
                    IsDeleted = false
                };
                var result = await _userManager.CreateAsync(identityUser, model.Password);
                return identityUser.Id;
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
            
            //if (result.Succeeded)
            //{
            //    return  identityUser.Id;
            //}
            //else
            //{
            //    return ResponseMessages.UserNotCreated;
            //}
        }        

        /// <summary>
        /// Logins a user and Generates a JWT authentication Token
        /// Use for login
        /// </summary>
        /// <param name="model"></param>
        /// <returns>JWT Token</returns>
        public async Task<LoginManagerResponse> LoginUserAsync(LoginViewDTO model)
        {
            var user = await _userManager.FindByEmailAsync(model.Email);
            if (user == null || user.IsDeleted == true)
            {
                return new LoginManagerResponse
                {
                    Message = ResponseMessages.UserNotExist,
                    IsSuccess = false
                };
            }
            else if (!user.IsActive)
            {
                return new LoginManagerResponse
                {
                    Message = ResponseMessages.UserAccountIsDisable,
                    IsSuccess = false
                };
            }
            var result = await _userManager.CheckPasswordAsync(user, model.Password);
            if (!result)
                return new LoginManagerResponse
                {
                    Message = ResponseMessages.InvalidPassword,
                    IsSuccess = false
                };

            IList<string> role = await _userManager.GetRolesAsync(user);
            string userrole = role.FirstOrDefault();
            if (userrole == null)
            {
                return new LoginManagerResponse
                {
                    Message = ResponseMessages.RoleNotAssignedToLogin,
                    IsSuccess = false
                };
            }
            Claim[] claims = new[]
            {
                new Claim("Email", model.Email),
                new Claim(ClaimTypes.NameIdentifier,user.Id),
                new Claim(ClaimTypes.Role,userrole),
                new Claim("UserName",user.UserName)
        };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["AuthSettings:Key"]));
            var token = new JwtSecurityToken(
                issuer: _configuration["AuthSettings:Issuer"],
                audience: _configuration["AuthSettings:Audience"],
                claims: claims,
                expires: DateTime.Now.AddDays(30),
                signingCredentials: new SigningCredentials(key, SecurityAlgorithms.HmacSha256));
            string tokenAsString = new JwtSecurityTokenHandler().WriteToken(token);

            var flag = await _userManager.IsInRoleAsync(user, "Admin");
            return new LoginManagerResponse
            {
                Message = tokenAsString,
                IsSuccess = true,
                ExpireDate = token.ValidTo,
                UserId = user.Id,
                Role = userrole
            };
        }

        /// <summary>
        /// Soft delete a User
        /// soft delete user 
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="deletedBy"></param>
        /// <returns></returns>
        public async Task<string> DeleteUser(string userName, string deletedBy)
        {
            try
            {
                var user = _userManager.Users.FirstOrDefault(x => x.UserName == userName);
                user.IsDeleted = true;
                user.DeletedBy = deletedBy;
                user.DeletedOn = System.DateTime.Now;
                _dbContext.Attach(user);
                _dbContext.Entry(user).State = EntityState.Modified;
                await _dbContext.SaveChangesAsync();
                return user.Id;
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}
