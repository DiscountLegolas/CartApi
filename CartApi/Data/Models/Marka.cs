using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CartApi.Data.Models
{
    public class Marka
    {
        public int MarkaId { get; set; }
        public string Markaİsmi { get; set; }
        public virtual ICollection<Product> Ürünler { get; set; }
        public virtual ICollection<HizmetVerir> HizmetVerirs { get; set; }
    }
}