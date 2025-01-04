using Microsoft.AspNetCore.Identity;
using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ecommerce_Website_MVC.Data;

namespace ecommerce_Website_MVC.Models
{
    public class SeedData
    {

        public static async Task Initialize(IServiceProvider serviceProvider)
        {
            try
            {
                var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
                var userManager = serviceProvider.GetRequiredService<UserManager<IdentityUser>>();
                var context = serviceProvider.GetRequiredService<ecommerce_Website_MVCContext>();

                // S'assurer que la base de données est créée
                await context.Database.EnsureCreatedAsync();

                const string ADMIN_ROLE = "Admin";
                const string ADMIN_EMAIL = "lamhoubi2000@gmail.com";
                const string ADMIN_PASSWORD = "123456789abcDEF!";

                // Créer le rôle Admin
                if (!await roleManager.RoleExistsAsync(ADMIN_ROLE))
                {
                    var role = new IdentityRole(ADMIN_ROLE);
                    var roleResult = await roleManager.CreateAsync(role);

                    if (!roleResult.Succeeded)
                    {
                        throw new Exception($"Erreur création rôle: {string.Join(", ", roleResult.Errors.Select(e => e.Description))}");
                    }
                }

                // Vérifier si l'admin existe
                var adminUser = await userManager.FindByEmailAsync(ADMIN_EMAIL);

                if (adminUser == null)
                {
                    // Créer l'utilisateur admin
                    adminUser = new IdentityUser
                    {
                        UserName = ADMIN_EMAIL, // Utiliser l'email comme username
                        Email = ADMIN_EMAIL,
                        EmailConfirmed = true
                    };

                    var createUserResult = await userManager.CreateAsync(adminUser, ADMIN_PASSWORD);

                    if (!createUserResult.Succeeded)
                    {
                        throw new Exception($"Erreur création admin: {string.Join(", ", createUserResult.Errors.Select(e => e.Description))}");
                    }

                    // Ajouter au rôle Admin
                    var addToRoleResult = await userManager.AddToRoleAsync(adminUser, ADMIN_ROLE);

                    if (!addToRoleResult.Succeeded)
                    {
                        throw new Exception($"Erreur ajout rôle: {string.Join(", ", addToRoleResult.Errors.Select(e => e.Description))}");
                    }
                }
                else if (!await userManager.IsInRoleAsync(adminUser, ADMIN_ROLE))
                {
                    await userManager.AddToRoleAsync(adminUser, ADMIN_ROLE);
                }

                
                var createdUser = await userManager.FindByEmailAsync(ADMIN_EMAIL);
                if (createdUser != null)
                {
                    var roles = await userManager.GetRolesAsync(createdUser);
                    Console.WriteLine($"Admin créé avec succès. Rôles: {string.Join(", ", roles)}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erreur dans SeedData: {ex.Message}");
                throw;
            }
        }
    }
}
