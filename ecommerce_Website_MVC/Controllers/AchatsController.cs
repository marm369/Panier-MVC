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

namespace ecommerce_Website_MVC.Controllers
{
    public class AchatsController : Controller
    {
        private readonly ecommerce_Website_MVCContext _context;
        private readonly PanierService _panierService;

        public AchatsController(ecommerce_Website_MVCContext context,PanierService panierService)
        {
            _context = context;
            _panierService = panierService;
        }

        // GET: Achats
        public async Task<IActionResult> Index()
        {
            return View(await _context.Achat.ToListAsync());
        }

        // GET: Achats/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var achat = await _context.Achat
                .FirstOrDefaultAsync(m => m.id == id);
            if (achat == null)
            {
                return NotFound();
            }

            return View(achat);
        }

        // GET: Achats/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Achats/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,DateAchat,user_Id,Status")] Achat achat)
        {
            if (ModelState.IsValid)
            {
                _context.Add(achat);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(achat);
        }

        // GET: Achats/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var achat = await _context.Achat.FindAsync(id);
            if (achat == null)
            {
                return NotFound();
            }
            return View(achat);
        }

        // POST: Achats/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,DateAchat,user_Id,Status")] Achat achat)
        {
            if (id != achat.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(achat);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AchatExists(achat.id))
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
            return View(achat);
        }

        // GET: Achats/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var achat = await _context.Achat
                .FirstOrDefaultAsync(m => m.id == id);
            if (achat == null)
            {
                return NotFound();
            }

            return View(achat);
        }

        // POST: Achats/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var achat = await _context.Achat.FindAsync(id);
            _context.Achat.Remove(achat);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AchatExists(int id)
        {
            return _context.Achat.Any(e => e.id == id);
        }

        [HttpPost]
        public IActionResult AddToCart(int productId, int quantitySelected, int idCategorie,int page)
        {
            _panierService.AjouterAuPanier(productId, quantitySelected);
            switch (page)
            {
                case 0:
                    return RedirectToAction("Index", "Produits", new { idCategorie = idCategorie });
                case 1:
                    return RedirectToAction("Details", "Produits", new { productId = productId });
                default:
                    return RedirectToAction("Index", "Produits", new { idCategorie = idCategorie });

            }
            

        }

        public IActionResult GetPanier()
        {
            var panierItems = _panierService.GetCartItems();
            return View("~/Views/Panier/Index.cshtml", panierItems);
        }

        public IActionResult SupprimerProduitDuPanier(int productId)
        {
            var panierItems = _panierService.SupprimerProduit(productId);
            return RedirectToAction(nameof(GetPanier));
        }
    }
}
