using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using FieldMgt.Core.DomainModels;
using Microsoft.EntityFrameworkCore;
using FieldMgt.Core.Interfaces;
using FieldMgt.Repository.Repository;
using FieldMgt.Repository.UOW;
using FieldMgt.API.Infrastructure.Extensions;
using Microsoft.AspNetCore.Authorization;
using FieldMgt.Core.UOW;
using Microsoft.OpenApi.Models;
using FieldMgt.API.Infrastructure.MiddleWares.ErrorHandler;
using FieldMgt.API.Infrastructure.Factories.PathProvider;
using Excepticon.Extensions;
using Excepticon.AspNetCore;
using FieldMgt.Repository.Repository.Exceptions;
using Microsoft.AspNetCore.Http;
using FieldMgt.Repository.AutoMapper;
using AutoMapper;

namespace FieldMgt
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public IConfiguration Configuration { get; }
        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            //services.AddDbContext<ApplicationDbContext>(options => options.UseInMemoryDatabase(databaseName: "MockDb"));
            services.AddControllers();
            services.AddHttpClient();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Lead Management",
                });
            });
            services.AddIdentity(Configuration);
            services.AddExcepticon();
            services.AddBrowserDetection();
            services.AddSingleton<IPathProvider, PathProvider>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IRoleRepository, RoleRepository>();
            services.AddTransient<IAddressDetailRepository, AddressDetailRepository>();
            services.AddTransient<IContactDetailRepository, ContactDetailRepository>();
            services.AddTransient<IUnitofWork, UnitofWork>();
            services.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddTransient<IAuthorizationHandler, CustomRequireClaimHandler>();
            services.AddTransient<IExceptionInterface, ExceptionRepository>();
            //services.AddAutoMapper(typeof(Startup));
            MapperConfiguration mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new CreateServiceMap());
            });
            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);
        }
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseMiddleware(typeof(ErrorHandlingMiddleware));
            app.UseExcepticon();
            app.UseRouting();            
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Lead Management");
            });
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
