using FieldMgt.Core.DomainModels;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.Text;

namespace FieldMgt.API.Infrastructure.Extensions
{
    public static class IdentityExtension
    {
        public static object Configuration { get; private set; }

        public static void AddIdentity(this IServiceCollection services, IConfiguration Configuration)
        {
            //services.AddIdentity<IdentityUser, IdentityRole>(options =>
            //{
            //    options.Password.RequireDigit = true;
            //    options.Password.RequireLowercase = true;
            //    options.Password.RequiredLength = 6;
            //}).AddRoles<IdentityRole>()
            //    .AddEntityFrameworkStores<ApplicationDbContext>()
            // .AddDefaultTokenProviders();
            services.AddIdentity<ApplicationUser, IdentityRole>(options =>
            {
                options.Password.RequireDigit = true;
                options.Password.RequireLowercase = true;
                options.Password.RequiredLength = 6;
            }).AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
             .AddDefaultTokenProviders();

            services.AddAuthentication(auth =>
            {
                auth.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                auth.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.SaveToken = true;
                options.RequireHttpsMetadata = false;
                options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
                {
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ValidAudience = Configuration["AuthSettings:Audience"],
                    ValidIssuer = Configuration["AuthSettings:Issuer"],
                    RequireExpirationTime = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["AuthSettings:Key"])),
                    ValidateIssuerSigningKey = true,
                    RoleClaimType = "role"
                };
            });
            services.AddAuthorization(config =>
            {
                //var defaultAuthBuilder = new AuthorizationPolicyBuilder();
                //var defaultAuthPolicy = defaultAuthBuilder
                //.RequireAuthenticatedUser()
                //.RequireClaim(ClaimTypes.Role)
                //.Build();
                //config.DefaultPolicy = defaultAuthPolicy;

                //can be used
                //config.AddPolicy("Claim.Role", policyBuilder =>
                //{ 
                // policyBuilder.AddRequirements(new CustomRequireClaim(ClaimTypes.Role));
                //});
                config.AddPolicy("Admin", policyBuilder => policyBuilder.RequireClaim(ClaimTypes.Role, "Admin"));
                config.AddPolicy("Operation Staff", policyBuilder => policyBuilder.RequireClaim(ClaimTypes.Role, "Operation Staff"));
                config.AddPolicy("Sales Operation", policyBuilder => policyBuilder.RequireClaim(ClaimTypes.Role, "Sales Operation"));
                //config.AddPolicy("Claim.Role", policyBuilder =>
                //{
                //    policyBuilder.RequireCustomClaim(ClaimTypes.Role);
                //});
            });

        }
    }
}

