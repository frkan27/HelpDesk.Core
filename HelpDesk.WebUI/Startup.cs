using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using HelpDesk.BLL;
using HelpDesk.BLL.Repository.Abstracts;
using HelpDesk.BLL.Repository.RoleUser;
using HelpDesk.DAL;
using HelpDesk.Model.Entities.Poco;
using HelpDesk.Model.Enums;
using HelpDesk.Model.IdentityEntities;
using HelpDesk.Model.ViewModels.FaultViewModels;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using HelpDesk.BLL.Repository.Fault_Repo;
using HelpDesk.BLL.Service.Sender;

namespace HelpDesk.WebUI
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
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddDbContext<MyContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection")));

            services.AddIdentity<ApplicationUser, ApplicationRole>()
                .AddEntityFrameworkStores<MyContext>();

            services.Configure<IdentityOptions>(options =>
            {
                // Password settings.
                options.Password.RequireDigit = true;
                options.Password.RequireLowercase = false;
                options.Password.RequireNonAlphanumeric = true;
                options.Password.RequireUppercase = true;
                options.Password.RequiredLength = 6;
                options.Password.RequiredUniqueChars = 0;

                // Lockout settings.
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(30);
                options.Lockout.MaxFailedAccessAttempts = 3;
                options.Lockout.AllowedForNewUsers = false;

                // User settings.
                options.User.AllowedUserNameCharacters =
                    "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
                options.User.RequireUniqueEmail = true;
            });

            services.ConfigureApplicationCookie(options =>
            {
                // Cookie settings
                options.Cookie.HttpOnly = true;
                options.ExpireTimeSpan = TimeSpan.FromMinutes(5);

                options.LoginPath = "/Account/Login";
                options.AccessDeniedPath = "/Identity/Account/AccessDenied";
                options.SlidingExpiration = true;
            });

            //services.AddScoped<IRepository<Issue, string>, IssueRepo>();
            //services.AddScoped<IRepository<IssueLog, string>, IssueLogRepo>();
            //services.AddScoped<IRepository<Photograph, string>, PhotographRepo>();
            //services.AddScoped<IRepository<Survey, string>, SurveyRepo>();

            services.AddScoped<IRepoIdentity, RoleUserRepo>();
            services.AddScoped<SignInManager<ApplicationUser>, SignInManager<ApplicationUser>>();
            services.AddScoped<UserManager<ApplicationUser>, UserManager<ApplicationUser>>();
            services.AddScoped<RoleManager<ApplicationRole>, RoleManager<ApplicationRole>>();
            services.AddScoped<IRepository<FaultRecord, int>, Fault_Repo>();
            services.AddScoped<MembershipTools, MembershipTools>();
            services.AddScoped<EMailService, EMailService>();
            services.AddScoped<RoleUserRepo, RoleUserRepo>();
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            services.AddAutoMapper();

            Mapper.Initialize(MapConfig);

            services.AddAuthorization(options =>
            {
                options.AddPolicy("RequireAdministratorRole",
                    policy => policy.RequireRole(IdentityRoles.Admin.ToString()));
            });
            services.AddAuthorization(options =>
            {
                options.AddPolicy("RequireUserRole",
                    policy => policy.RequireRole(IdentityRoles.Customer.ToString()));
            });
        }
        private void MapConfig(IMapperConfigurationExpression cfg)
        {
            cfg.CreateMap<FaultRecord, FaultViewModels>()
                .ForMember(dest => dest.FaultId, opt => opt.MapFrom(x => x.Id))
                .ReverseMap();
        }
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseAuthentication();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
