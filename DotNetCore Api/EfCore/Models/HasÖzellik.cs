using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetCore_Api.EfCore.Models
{
    public class HasÖzellik
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int ÖzellikId { get; set; }
        public virtual Product Product { get; set; }
        public virtual Özellik Özellik { get; set; }
    }
}
