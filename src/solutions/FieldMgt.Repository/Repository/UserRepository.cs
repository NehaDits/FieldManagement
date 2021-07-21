using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using System.Text;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using FieldMgt.Core.Interfaces;
using FieldMgt.Core.DomainModels;
using System.Collections.Generic;
using FieldMgt.Core.DTOs;
using Microsoft.EntityFrameworkCore;
using FieldMgt.Core.DTOs.Response;
using FieldMgt.Core.DTOs.Request;

namespace FieldMgt.Repository.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly UserManager<ApplicationUser> _userManager;

        private IConfiguration _configuration;
        private ApplicationDbContext _dbContext;
        public UserRepository(UserManager<ApplicationUser> userManager, ApplicationDbContext dbcontext, IConfiguration configuration)
        {
            _userManager = userManager;
            _configuration = configuration;
            _dbContext = dbcontext;            
        }
        public async Task<UserManagerReponse> RegisterUserAsync(RegisterUserDTO model)
        {
            if (model == null)
            {
                throw new NullReferenceException("Register Model is Empty");
            }
            if (model.Password != model.ConfirmPassword)
                return new UserManagerReponse
                {
                    Message = "Confirm Password doesn't match Password",
                    IsSuccess = false
                };
            var identityUser = new ApplicationUser
            {
                Email = model.Email,
                UserName = model.Email,
                CreatedBy = model.CreatedBy,
                CreatedOn=model.CreatedOn,
                IsActive = true,
                IsDeleted =false
            };
            var result = await _userManager.CreateAsync(identityUser, model.Password);
            if (result.Succeeded)
            {
                return new UserManagerReponse
                {
                    Message = "User Created Successfully",
                    IsSuccess = true,
                    Id = identityUser.Id
                 };
             }
        else
         {    
        return new UserManagerReponse
            {
                Message = "User not created",
                IsSuccess = false,
                Errors = result.Errors.Select(e => e.Description)
            };
        }        
}
        public async Task<LoginManagerResponse> LoginUserAsync(LoginViewDTO model)
        {
            var user = await _userManager.FindByEmailAsync(model.Email);
            if (user == null || user.IsDeleted == true)
            {
                return new LoginManagerResponse
                {
                    Message = "User doesn't exist",
                    IsSuccess = false
                };
            }
            else if (!user.IsActive)
            {
                return new LoginManagerResponse
                {
                    Message = "User has been disabled by the Admin",
                    IsSuccess = false
                };
            }
            var result = await _userManager.CheckPasswordAsync(user, model.Password);
            if (!result)
                return new LoginManagerResponse
                {
                    Message = "Invalid Password",
                    IsSuccess = false
                };

            IList<string> role = await _userManager.GetRolesAsync(user);
            string userrole = role.FirstOrDefault();
            if (userrole == null)
            {
                return new LoginManagerResponse
                {
                    Message = "User is not assigned a role to Login",
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
        public async Task<string> DeleteUser(string userName, string deletedBy)
        {
            var user = _userManager.Users.FirstOrDefault(x => x.UserName == userName);
            if(user.IsDeleted==true || user==null)
            {
                return null;
            }
            else
            {
                user.IsDeleted = true;
                user.DeletedBy = deletedBy;
                user.DeletedOn = System.DateTime.Now;
                _dbContext.Attach(user);
                _dbContext.Entry(user).State = EntityState.Modified;
                await _dbContext.SaveChangesAsync();
                return user.Id;
            }
            
        }
       
    }
}
