using ecommerce_Website_MVC.Data;
using ecommerce_Website_MVC.Models;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ecommerce_Website_MVC.Services
{
    public class PanierService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ecommerce_Website_MVCContext _context;
        private readonly ProduitService _produitService;

        public List<LignePanier> lignePaniers { get; set; }

        public PanierService(IHttpContextAccessor httpContextAccessor, ecommerce_Website_MVCContext context,ProduitService produitService)
        {
            _httpContextAccessor = httpContextAccessor;
            _context = context;
            _produitService = produitService;
        }

        private string GetCartCookieName()
        {
            var userId = _httpContextAccessor.HttpContext.User.Identity.IsAuthenticated ?
                _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value :
                "Cart_Anonymous";
            return $"Cart_{userId}";
        }

        public List<LignePanier> GetCartItems()
        {
            var context = _httpContextAccessor.HttpContext;
            var cartCookie = context.Request.Cookies[GetCartCookieName()];

            if (string.IsNullOrEmpty(cartCookie))
            {
                return new List<LignePanier>();
            }

            return JsonConvert.DeserializeObject<List<LignePanier>>(cartCookie);
        }
        public void SaveCartItems(List<LignePanier> cartItems)
        {
            var context = _httpContextAccessor.HttpContext;
            var options = new CookieOptions
            {
                Expires = DateTimeOffset.UtcNow.AddDays(30)
            };

            var json = JsonConvert.SerializeObject(cartItems);
            context.Response.Cookies.Append(GetCartCookieName(), json, options);
        }

        public void AjouterAuPanier(int productId, int quantitySelected)
        {
            lignePaniers = GetCartItems() ?? new List<LignePanier>();
            var produit = _produitService.FindProduct(productId);
            if(produit == null)
            {
                return;
            }
            var existingItem = lignePaniers.Find(i => i.id_produit == productId);
            if (existingItem != null)
            {
                existingItem.quantite_ligne += quantitySelected;
            }
            else
            {
                var ligne = new LignePanier
                {
                    quantite_ligne = quantitySelected,
                    prixdevente = produit.prixProduit,
                    id_produit = produit.id,
                    produit = produit,
                    achat = null,
                };
                lignePaniers.Add(ligne);
            }

            SaveCartItems(lignePaniers);
        }

        public List<LignePanier> SupprimerProduit(int ProductId)
        {
            lignePaniers = GetCartItems();
            if (lignePaniers == null || !lignePaniers.Any(item => item.produit.id == ProductId))
            {
                return lignePaniers;
            }
            var itemToRemove = lignePaniers.FirstOrDefault(item => item.produit.id == ProductId);
            if (itemToRemove != null)
            {
                lignePaniers.Remove(itemToRemove);
                SaveCartItems(lignePaniers);
            }
            return GetCartItems();
        }
    }
}
