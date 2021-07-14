using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetCore_Api.Models.Resources
{
    public class CategoryResource
    {
        public int KategoriId { get; set; }
        public string Kategoriİsmi { get; set; }
        public ÜstCategoryResource ÜstKategori { get; set; }
        public ICollection<AltCategoryResource> AltKategoriler { get; set; }
    }

    public class AltCategoryResource
    {
        public int KategoriId { get; set; }
        public string Kategoriİsmi { get; set; }
        public ICollection<AltCategoryResource> AltKategoriler { get; set; }
    }

    public class ÜstCategoryResource
    {
        public int KategoriId { get; set; }
        public string Kategoriİsmi { get; set; }
        public ÜstCategoryResource ÜstKategori { get; set; }
    }
}
