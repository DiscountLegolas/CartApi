using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CartApi.Data.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        public double Price { get; set; }
        public int MarkaId { get; set; }
        public virtual Marka Marka { get; set; }
        public int KategoriId { get; set; }
        public virtual Kategori Kategori { get; set; }
        public virtual ICollection<ProductIncart> CartsThatHavaProduct { get; set; }
    }
}