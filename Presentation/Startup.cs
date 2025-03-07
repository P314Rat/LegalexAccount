using Application.Core.Services;
using Application.Core.Services.Static;
using Domain.Core.UserAggregate;
using Infrastructure;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using Utilities.Types;


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
            services.AddMailService(Configuration.GetSection("MailSettings"));
            services.AddHttpContextAccessor();
            services.AddControllersWithViews().AddRazorRuntimeCompilation();
            services.AddMediatR(config => config.RegisterServicesFromAssembly(typeof(ServiceRegistrator).Assembly));
            services.AddHandlerValidator();
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

            using (var scope = app.ApplicationServices.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

                if (dbContext.Database.GetPendingMigrations().Any())
                {
                    dbContext.Database.Migrate();
                }

                if (!dbContext.Specialists.Any())
                {
                    var salt1 = GenerateDataService.GenerateSalt(32);
                    var salt2 = GenerateDataService.GenerateSalt(32);
                    dbContext.Specialists.AddRange(
                        new Specialist
                        {
                            Status = SpecialistStatus.Free,
                            Role = SpecialistType.Technical,
                            Email = "support@legalex.by",
                            PasswordHash = GenerateDataService.GenerateHash("1234dev!", salt1),
                            PasswordSalt = salt1,
                            FirstName = "Тимофей",
                            LastName = "Липницкий",
                        },
                        new Specialist
                        {
                            Status = SpecialistStatus.Free,
                            Role = SpecialistType.Director,
                            Email = "vv95@bk.ru",
                            PasswordHash = GenerateDataService.GenerateHash("Peredovaya15!", salt2),
                            PasswordSalt = salt2,
                            FirstName = "Владислав",
                            LastName = "Власенков",
                        }
                    );

                    dbContext.SaveChanges();
                }
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
                //endpoints.MapHub<PresenceHub>("/presence");
            });
        }
    }
}