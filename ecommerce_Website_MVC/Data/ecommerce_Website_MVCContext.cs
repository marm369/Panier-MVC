using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ecommerce_Website_MVC.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace ecommerce_Website_MVC.Data
{
    public class ecommerce_Website_MVCContext : IdentityDbContext<IdentityUser>
    {
        public ecommerce_Website_MVCContext (DbContextOptions<ecommerce_Website_MVCContext> options)
            : base(options)
        {
        }

        public DbSet<ecommerce_Website_MVC.Models.Categorie> Categorie { get; set; }

        public DbSet<ecommerce_Website_MVC.Models.Produit> Produit { get; set; }

        public DbSet<ecommerce_Website_MVC.Models.Achat> Achat { get; set; }
    }
}
