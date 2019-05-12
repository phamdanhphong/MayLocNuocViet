using System;
using AutoMapper;
using Fsoft.SKU.CoreApp.Data.EF;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using MLT.MayLocNuocViet.Data.EF;
using MLT.MayLocNuocViet.Data.Entities;
using MLT.MayLocNuocViet.Infrastructure.Implementation;
using MLT.MayLocNuocViet.Infrastructure.Interfaces;
using MLT.MayLocNuocViet.Web.Extensions;
using MLT.MayLocNuocViet.Web.Helpers;
using Newtonsoft.Json.Serialization;
using Microsoft.Extensions.Configuration;
using MLT.MayLocNuocViet.Services.AutoMapper;

namespace MLT.MayLocNuocViet.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<AppDbContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"),
            o => o.MigrationsAssembly("MayLocNuocViet.Data.EF")));

         
            services.AddIdentity<Employee, Role>()
                .AddEntityFrameworkStores<AppDbContext>()
                .AddDefaultTokenProviders();

            services.AddMemoryCache();

            services.AddMinResponse();

            // Configure Identity
            services.Configure<IdentityOptions>(options =>
            {
                // Password settings
                options.Password.RequireDigit = true;
                options.Password.RequiredLength = 6;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireLowercase = false;

                // Lockout settings
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(30);
                options.Lockout.MaxFailedAccessAttempts = 10;

                // User settings
                options.User.RequireUniqueEmail = true;
            });

            services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromHours(2);
                options.Cookie.HttpOnly = true;
            });

             services.AddImageResizer();

             services.AddAutoMapper();
            AutoMapperConfig.RegisterMappings();

            // Add application services.
            services.AddScoped<UserManager<Employee>, UserManager<Employee>>();
            services.AddScoped<RoleManager<Role>, RoleManager<Role>>();

            //services.AddSingleton(Mapper.Configuration);
            services.AddScoped<IMapper>(sp => new Mapper(sp.GetRequiredService<AutoMapper.IConfigurationProvider>(), sp.GetService));

            services.AddTransient<DbInitializer>();

            services.AddScoped<IUserClaimsPrincipalFactory<Employee>, CustomClaimsPrincipalFactory>();

            services.AddMvc(options =>
            {
                options.CacheProfiles.Add("Default",
                    new CacheProfile()
                    {
                        Duration = 60
                    });
                options.CacheProfiles.Add("Never",
                    new CacheProfile()
                    {
                        Location = ResponseCacheLocation.None,
                        NoStore = true
                    });
            }).AddJsonOptions(options => options.SerializerSettings.ContractResolver = new DefaultContractResolver());


            services.AddTransient(typeof(IEFUnitOfWork), typeof(EFUnitOfWork));
            services.AddTransient(typeof(IEFRepository<>), typeof(EFRepository<>));
            //Serrvices
            //services.AddTransient<IProductCategoryService, ProductCategoryService>();
            //services.AddTransient<IFunctionService, FunctionService>();
            //services.AddTransient<IProductService, ProductService>();
            //services.AddTransient<IUserService, UserService>();
            //services.AddTransient<IRoleService, RoleService>();
            //services.AddTransient<IBillService, BillService>();
            //services.AddTransient<IBlogService, BlogService>();
            //services.AddTransient<ICommonService, CommonService>();
            //services.AddTransient<IFeedbackService, FeedbackService>();
            //services.AddTransient<IContactService, ContactService>();
            //services.AddTransient<IPageService, PageService>();
            //services.AddTransient<IReportService, ReportService>();
            //services.AddTransient<IAnnouncementService, AnnouncementService>();

            //services.AddTransient<IAuthorizationHandler, BaseResourceAuthorizationHandler>();

            services.AddSignalR();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddFile("Logs/log-{Date}.txt");
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                //app.UseBrowserLink();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseImageResizer();
            app.UseStaticFiles();
            app.UseMinResponse();
            app.UseAuthentication();
            app.UseSession();

            var options = app.ApplicationServices.GetService<IOptions<RequestLocalizationOptions>>();
            app.UseRequestLocalization(options.Value);
            app.UseCors("CorsPolicy");
           
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");

                routes.MapRoute(name: "areaRoute",
                    template: "{area:exists}/{controller=Login}/{action=Index}/{id?}");
            });
        }
    }
}
