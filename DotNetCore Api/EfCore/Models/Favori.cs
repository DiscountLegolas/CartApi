using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetCore_Api.EfCore.Models
{
    public class Favori
    {
        public int FavoriId { get; set; }
        public int UserId { get; set; }
        public int ProductId { get; set; }
        public virtual User User { get; set; }
        public virtual Product Product { get; set; }
    }
}
