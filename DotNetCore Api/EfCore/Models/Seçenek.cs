using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetCore_Api.EfCore.Models
{
    public class Seçenek
    {
        [ForeignKey("Özellik")]
        public int Id { get; set; }
        public string Name { get; set; }
        public int FilterId { get; set; }
        public virtual Filter Filter { get; set; }
        public virtual Özellik Özellik { get; set; }
    }
}
