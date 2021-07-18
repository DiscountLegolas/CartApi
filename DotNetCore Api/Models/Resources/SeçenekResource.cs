using DotNetCore_Api.EfCore.Models;
using System.Collections.Generic;
using System.Linq;

namespace DotNetCore_Api.Models.Resources
{
    public class SeçenekResource
    {
        public int SeçenekId { get; set; }
        public string Name { get; set; }
        public List<Product> ApplySeçenek(List<Product> products)
        {
            return products.Where(x => x.Özelliks.Any(a => a.Özellik.ÖzellikId == SeçenekId)).ToList();
        }
    }
}