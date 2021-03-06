using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using TestProj.Application.Services;
using TestProj.Application.Services.Contracts;
using TestProj.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;

namespace TestProj
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
            var serverVersion = new MySqlServerVersion(new Version(8, 0, 25));

            services.AddHttpContextAccessor();

            services.AddDbContext<DatabaseContext>(
                dbContextOptions =>
                {
                    dbContextOptions.UseMySql(Configuration.GetConnectionString("MySqlConnection"), serverVersion)
                                    .EnableSensitiveDataLogging();
                });

            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<ITestsService, TestsService>();

            services.AddAutoMapper((config) =>
            {
                config.AddMaps(typeof(Mapping.AuthProfile).Assembly,
                               typeof(Application.Mapping.AuthProfile).Assembly);
            });
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(options =>
                {
                    options.LoginPath = new Microsoft.AspNetCore.Http.PathString("/Account/Login");
                });

            services.AddControllersWithViews().AddRazorRuntimeCompilation();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
