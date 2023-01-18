using InternetShop.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternetShop.Domain.Entity
{
    public class Clothes
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public Gender Gender { get; set; }
        public СlothingType СlothingType { get; set; }
        public Color Color { get; set; }
        public Size Size { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
    }
}
