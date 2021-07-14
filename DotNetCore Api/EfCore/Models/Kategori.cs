using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetCore_Api.EfCore.Models
{
    public class Kategori
    {
        public int KategoriId { get; set; }
        public string Kategoriİsmi { get; set; }
        [ForeignKey("ÜstKategori")]
        public Nullable<int> ÜstKategoriId { get; set; }
        public Kategori ÜstKategori { get; set; }
        public ICollection<Kategori> AltKategoriler { get; set; }
        public virtual ICollection<Product> ProductsOnCategory { get; set; }
        public virtual ICollection<AppliesTo> AppliesTos { get; set; }
    }
}
