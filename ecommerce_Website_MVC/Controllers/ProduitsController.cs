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
using Microsoft.AspNetCore.Http;

namespace ecommerce_Website_MVC.Controllers
{
    public class ProduitsController : Controller
    {
        private readonly ecommerce_Website_MVCContext _context;
        private readonly ImageService _imageService;
        private readonly ProduitService _produitService;

        public ProduitsController(ecommerce_Website_MVCContext context, ImageService imageService, ProduitService produitService)
        {
            _context = context;
            _imageService = imageService;
            _produitService = produitService;
        }

        // GET: Produits
        public async Task<IActionResult> Index(int? idCategorie)
        {
            var produits = await _context.Produit
                .Where(p => p.categorieId == idCategorie)
                .ToListAsync();
            return View(produits);
        }

        // GET: Produits/Details/5
        public async Task<IActionResult> Details(int? productId)
        {
            if (productId == null)
            {
                return NotFound();
            }

            var produit = await _context.Produit
                .Include(p => p.categorie)
                .FirstOrDefaultAsync(m => m.id == productId);
            if (produit == null)
            {
                return NotFound();
            }

            return View(produit);
        }

        // GET: Produits/Create
        public IActionResult Create()
        {
            ViewData["categorieId"] = new SelectList(_context.Categorie, "id", "nomCategorie");
            return View();
        }

        // POST: Produits/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Produit produit, IFormFile upload)
        {
            if(!ModelState.IsValid)
            {
                ViewData["categorieId"] = new SelectList(_context.Categorie, "id", "nomCategorie", produit.categorieId);
                return View(produit);
            }
            if (upload == null || upload.Length == 0)
            {
                ModelState.AddModelError(string.Empty, "Veuillez sélectionner une image à télécharger.");
                ViewData["categorieId"] = new SelectList(_context.Categorie, "id", "nomCategorie", produit.categorieId);
                return View(produit);
            }
            try
            {
                // Utilise le service d'image pour uploader et obtenir l'URL
                var uploadResult = await _imageService.UploadImageAsync(upload);
                if (uploadResult != null)
                {
                    produit.imageUrl = uploadResult;
                }
            }
            catch(Exception ex)
            {
                ModelState.AddModelError(string.Empty, "Erreur lors de l'upload de l'image : " + ex.Message);
                ViewData["categorieId"] = new SelectList(_context.Categorie, "id", "nomCategorie", produit.categorieId);

                return View(produit);
            }

            produit.dateAjout = DateTime.Now;
            _context.Produit.Add(produit);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));

        }

        // GET: Produits/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var produit = await _context.Produit.FindAsync(id);
            if (produit == null)
            {
                return NotFound();
            }
            ViewData["categorieId"] = new SelectList(_context.Categorie, "id", "id", produit.categorieId);
            return View(produit);
        }

        // POST: Produits/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,nomProduit,description,prixProduit,qteStock,dateAjout,categorieId,imageUrl")] Produit produit)
        {
            if (id != produit.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(produit);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProduitExists(produit.id))
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
            ViewData["categorieId"] = new SelectList(_context.Categorie, "id", "id", produit.categorieId);
            return View(produit);
        }

        // GET: Produits/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var produit = await _context.Produit
                .Include(p => p.categorie)
                .FirstOrDefaultAsync(m => m.id == id);
            if (produit == null)
            {
                return NotFound();
            }

            return View(produit);
        }

        public IActionResult searchProductByName(string searchTerm)
        {
            List<Produit> produits = null;
            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                produits = _produitService.searchProductByName(searchTerm);
            }
            else
            {
                produits = new List<Produit>();
            }
            return View("ProductsByName", produits);
        }

        // POST: Produits/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var produit = await _context.Produit.FindAsync(id);
            _context.Produit.Remove(produit);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProduitExists(int id)
        {
            return _context.Produit.Any(e => e.id == id);
        }
    }
}
