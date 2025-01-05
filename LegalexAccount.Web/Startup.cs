using LegalexAccount.BLL.DTO;
using LegalexAccount.BLL.Services;
using LegalexAccount.DAL.Models.UserAggregate;
using LegalexAccount.DAL;
using LegalexAccount.Utility.Services;
using LegalexAccount.Utility.Types;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;


namespace LegalexAccount.Web
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
            //services.AddCors(options =>
            //{
            //    options.AddPolicy("AllowAll",
            //        builder =>
            //        {
            //            builder
            //                .AllowAnyOrigin()
            //                .AllowAnyMethod()
            //                .AllowAnyHeader();
            //        });
            //});
            services.AddApplicationDbContext(Configuration["ConnectionStrings:DefaultConnection"]);
            services.AddUnitOfWork();
            services.AddHttpContextAccessor(); // Регистрируем IHttpContextAccessor
            services.AddControllersWithViews().AddRazorRuntimeCompilation();
            services.AddMediatR(config => config.RegisterServicesFromAssembly(typeof(UserDTO).Assembly));
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

            // Применяем миграции и инициализируем данные
            using (var scope = app.ApplicationServices.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

                // Применяем миграции, если есть
                if (dbContext.Database.GetPendingMigrations().Any())
                {
                    dbContext.Database.Migrate();
                }

                // Инициализация данных (например, добавление специалистов)
                if (!dbContext.Specialists.Any())
                {
                    var salt = GenerateDataService.CreateSalt(32);
                    dbContext.Specialists.AddRange(
                        new Specialist
                        {
                            Status = SpecialistStatus.Free,
                            Role = SpecialistRole.Technical,
                            Email = "support@legalex.by",
                            PasswordHash = GenerateDataService.GenerateHash("1234dev!", salt),
                            PasswordSalt = salt,
                            FirstName = "Тимофей",
                            LastName = "Липницкий",
                        },
                        new Specialist
                        {
                            Status = SpecialistStatus.Free,
                            Role = SpecialistRole.Director,
                            Email = "vv95@bk.ru",
                            PasswordHash = GenerateDataService.GenerateHash("Peredovaya15!", salt),
                            PasswordSalt = salt,
                            FirstName = "Владислав",
                            LastName = "Власенков",
                        }
                    );

                    dbContext.SaveChanges();
                }
            }

            app.UseHttpsRedirection();
            app.UseRouting();

            //app.UseCors();

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