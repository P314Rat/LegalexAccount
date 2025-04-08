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

            app.UseStaticFiles(new StaticFileOptions
            {
                OnPrepareResponse = ctx =>
                {
                    ctx.Context.Response.Headers.Append("Cache-Control", "public,max-age=172800");
                }
            });

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            // Перенаправление по роли
            app.Use(async (context, next) =>
            {
                
                if (context.Request.Path == "/")
                {
                    var user = context.User;

                    if (user.Identity?.IsAuthenticated == true &&
                        (user.IsInRole("Director") || user.IsInRole("Technical") || user.IsInRole("Specialist")))
                    {
                        context.Response.Redirect("/Home/Orders");
                        return;
                    }
                    else
                    {
                        context.Response.Redirect("/Home/Cases");
                        return;
                    }
                }

                await next();
            });

            app.UseStatusCodePagesWithReExecute("/Error/{0}");

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