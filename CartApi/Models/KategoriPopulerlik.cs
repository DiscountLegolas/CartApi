using CartApi.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CartApi.Models
{
    public class KategoriPopulerlik
    {
        public Kategori Kategori { get; set; }
        public int populerlik { get; set; }
    }
}