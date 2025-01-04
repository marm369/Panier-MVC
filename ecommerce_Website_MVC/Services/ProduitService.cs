using ecommerce_Website_MVC.Data;
using ecommerce_Website_MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ecommerce_Website_MVC.Services
{
    public class ProduitService
    {
        private readonly ecommerce_Website_MVCContext context;

        public ProduitService(ecommerce_Website_MVCContext _context)
        {
            context = _context;
        }

        public Produit FindProduct(int productId)
        {
            return context.Produit.SingleOrDefault(p => p.id == productId);
        }

        public List<Produit> searchProductByName(string nomProduit)
        {
            return context.Produit
                .Where(p => p.nomProduit.Contains(nomProduit) || p.description.Contains(nomProduit))
                .ToList();
        }
    }
}
