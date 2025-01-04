using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ecommerce_Website_MVC.Data;
using ecommerce_Website_MVC.Models;
using ecommerce_Website_MVC.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Identity;

namespace ecommerce_Website_MVC.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly ecommerce_Website_MVCContext _context;

        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly SignInManager<IdentityUser> _signInManager;

        public CategoriesController(ecommerce_Website_MVCContext context, UserManager<IdentityUser> userManager,
        RoleManager<IdentityRole> roleManager,
        SignInManager<IdentityUser> signInManager)
        {
            _context = context;

            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;
        }

        // GET: Categories
        public async Task<IActionResult> Index()
        {
            var categories = await _context.Categorie
                .Include(c => c.produits)
                .Select(c => new CategorieViewModel
                {
                    id = c.id,
                    nomCategorie = c.nomCategorie,
                    imageUrls = c.produits.Select(p => p.imageUrl)
                    .Take(4)
                    .ToList()
                })
                .ToListAsync();
            return View(categories);
        }

        // GET: Categories/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var categorie = await _context.Categorie
                .FirstOrDefaultAsync(m => m.id == id);
            if (categorie == null)
            {
                return NotFound();
            }

            return View(categorie);
        }

        // GET: Categories/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Categories/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,nomCategorie")] Categorie categorie)
        {
            if (ModelState.IsValid)
            {
                _context.Add(categorie);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(categorie);
        }

        // GET: Categories/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var categorie = await _context.Categorie.FindAsync(id);
            if (categorie == null)
            {
                return NotFound();
            }
            return View(categorie);
        }

        // POST: Categories/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,nomCategorie")] Categorie categorie)
        {
            if (id != categorie.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(categorie);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CategorieExists(categorie.id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(categorie);
        }

        // GET: Categories/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var categorie = await _context.Categorie
                .FirstOrDefaultAsync(m => m.id == id);
            if (categorie == null)
            {
                return NotFound();
            }

            return View(categorie);
        }

        // POST: Categories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var categorie = await _context.Categorie.FindAsync(id);
            _context.Categorie.Remove(categorie);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CategorieExists(int id)
        {
            return _context.Categorie.Any(e => e.id == id);
        }


        public async Task<IActionResult> Debug()
        {
            var viewModel = new List<string>();

            // Vérifier si le rôle Admin existe
            var adminRole = await _roleManager.FindByNameAsync("Admin");
            viewModel.Add($"Role Admin exists: {adminRole != null}");

            // Vérifier si l'utilisateur admin existe
            var adminUser = await _userManager.FindByEmailAsync("lamhoubi2000@gmail.com");
            viewModel.Add($"Admin user exists: {adminUser != null}");

            if (adminUser != null)
            {
                // Vérifier les rôles de l'utilisateur
                var userRoles = await _userManager.GetRolesAsync(adminUser);
                viewModel.Add($"User roles: {string.Join(", ", userRoles)}");

                // Vérifier si le mot de passe est valide
                var passwordValid = await _userManager.CheckPasswordAsync(adminUser, "123456789abcDEF!");
                viewModel.Add($"Password is valid: {passwordValid}");

                // Vérifier si l'email est confirmé
                viewModel.Add($"Email confirmed: {adminUser.EmailConfirmed}");
            }

            return View(viewModel);
        }
    }
}
