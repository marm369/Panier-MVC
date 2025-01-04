using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ecommerce_Website_MVC.Services
{
    public class CategorieViewModel
    {
        public int id { get; set; }
        public string nomCategorie { get; set; }
        public List<string> imageUrls { get; set; } = new List<string>();
    }
}
