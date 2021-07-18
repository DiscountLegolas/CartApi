using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetCore_Api.EfCore.Models
{
    public class Özellik
    {
        public int ÖzellikId { get; set; }
        public string Name { get; set; }
        public virtual Seçenek Seçenek { get; set; }
        public virtual ICollection<HasÖzellik> HasÖzelliks { get; set; }
    }
}
