using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetCore_Api.EfCore.Models
{
    public class Cart
    {
        [ForeignKey("User")]
        public int CartId { get; set; }
        public virtual ICollection<ProductIncart> ProductIncarts { get; set; }
        public virtual User User { get; set; }
    }
}
