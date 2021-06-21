using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetCore_Api.EfCore.Models
{
    public class HizmetVerir
    {
        public int HizmetVerirId { get; set; }
        public int MarkaId { get; set; }
        public virtual Marka Marka { get; set; }
        public int KategoriId { get; set; }
        public virtual Kategori Kategori { get; set; }
    }
}
