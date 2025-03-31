using Application.Core.Services;
using Infrastructure;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Reflection;


namespace Presentation
{
    public class Startup
    {
        private IConfiguration Configuration { get; }


        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddApplicationDbContext(Configuration["ConnectionStrings:DefaultConnection"]);
            services.AddUnitOfWork();
            services.AddHttpContextAccessor();
            services.AddControllersWithViews().AddRazorRuntimeCompilation();

            var assembliesToScan = new[]
            {
                Assembly.Load("Application.Core"),
                Assembly.Load("Presentation")
            };

            services.AddAutoMapper(assembliesToScan);
            services.AddMediatR(config => config.RegisterServicesFromAssembly(typeof(ServiceRegistrator).Assembly));
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(options =>
                {
                    options.LoginPath = "/Account/Login";
                    options.LogoutPath = "/Account/Logout";
                    options.SlidingExpiration = false;
                    options.ExpireTimeSpan = TimeSpan.FromHours(12);
                });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
                app.UseExceptionHandler("/Error");
            }

            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseStatusCodePagesWithReExecute("/Error/{0}");
            app.UseStaticFiles(new StaticFileOptions
            {
                OnPrepareResponse = ctx =>
                {
                    ctx.Context.Response.Headers.Append("Cache-Control", "public,max-age=172800");
                }
            });
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Orders}/{id?}");
                endpoints.MapControllers();
            });
        }
    }
}