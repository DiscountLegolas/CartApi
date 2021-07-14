using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetCore_Api.EfCore.Models
{
    public class Filter
    {
        public int FilterId { get; set; }
        public string Name { get; set; }
        public virtual ICollection<AppliesTo> AppliesTos  { get; set; }
        public virtual ICollection<Seçenek> Seçenekler { get; set; }
    }
}
