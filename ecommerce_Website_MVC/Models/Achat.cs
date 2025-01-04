using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ecommerce_Website_MVC.Models
{
    public class Achat
    {
        public int id { get; set; }
        [DataType(DataType.Date)]
        public DateTime DateAchat { get; set; }
        public string user_Id { get; set; }
        public IdentityUser utilisateur { get; set; }
        public ICollection<LignePanier> lignesPanier { get; set; } = new List<LignePanier>();
        public string Status { get; set; }
    }
}
