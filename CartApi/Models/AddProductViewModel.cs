using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CartApi.Models
{
    public class AddProductViewModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public int MarkaId { get; set; }
        public int KategoriId { get; set; }
    }
    public class UpdateProductViewModel
    {
        [Required]
        public int ProductId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Nullable<double> Price { get; set; }
        public Nullable<int> MarkaId { get; set; }
        public Nullable<int> KategoriId { get; set; }
    }
}