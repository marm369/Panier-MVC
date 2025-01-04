using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ecommerce_Website_MVC.Data;
using ecommerce_Website_MVC.Models;
using Microsoft.AspNetCore.Identity;
using ecommerce_Website_MVC.Services;

namespace ecommerce_Website_MVC
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
            

            services.AddDbContext<ecommerce_Website_MVCContext>(options =>
                    options.UseSqlServer(Configuration.GetConnectionString("ecommerce_Website_MVCContext")));
            //options => options.SignIn.RequireConfirmedAccount = true
            
            services.AddDefaultIdentity<IdentityUser>() 
                .AddRoles<IdentityRole>()// Ajoutez IdentityRole pour gérer les rôles
                .AddEntityFrameworkStores<ecommerce_Website_MVCContext>()
                .AddDefaultUI()
                .AddDefaultTokenProviders();
            services.AddHttpContextAccessor();
            services.AddScoped<ImageService>();
            services.AddScoped<ProduitService>();
            services.AddScoped<PanierService>();
            services.AddControllersWithViews();
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
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();



            // Appel à SeedData pour initialiser les données
            using (var scope = app.ApplicationServices.CreateScope())
            {
                var services = scope.ServiceProvider;
                try
                {
                    var userManager = services.GetRequiredService<UserManager<IdentityUser>>();
                    var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();

                    // Vérifier si le rôle existe
                    var adminRole = roleManager.FindByNameAsync("Admin").Result;
                    Console.WriteLine($"Role Admin exists: {adminRole != null}");

                    // Vérifier si l'utilisateur existe
                    var adminUser = userManager.FindByEmailAsync("lamhoubi2000@gmail.com").Result;
                    Console.WriteLine($"Admin user exists: {adminUser != null}");

                    if (adminUser != null)
                    {
                        var userRoles = userManager.GetRolesAsync(adminUser).Result;
                        Console.WriteLine($"Admin user roles: {string.Join(", ", userRoles)}");
                    }

                    // Exécuter le SeedData
                    SeedData.Initialize(services).Wait();
                    var context = services.GetRequiredService<ecommerce_Website_MVCContext>();
                    context.Database.Migrate();

                    // Vérifier à nouveau après le seed
                    adminUser = userManager.FindByEmailAsync("lamhoubi2000@gmail.com").Result;
                    if (adminUser != null)
                    {
                        var userRoles = userManager.GetRolesAsync(adminUser).Result;
                        Console.WriteLine($"Admin user roles after seed: {string.Join(", ", userRoles)}");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"An error occurred while seeding the database: {ex.Message}");
                }
            }

                

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Categories}/{action=Index}");

                endpoints.MapRazorPages();
            });
        }
    }
}
