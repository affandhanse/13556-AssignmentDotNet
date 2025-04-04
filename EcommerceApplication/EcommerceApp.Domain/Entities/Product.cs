using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceApp.Domain.Entities
{
    public class Product:BaseEntity
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public double Price { get; set; } 
        public int Stock { get; set; }
        public string PictureUrl { get; set; }
        public int CategoryId { get; set; }
        public ProductCategory? Category { get; set; }
    }
}


