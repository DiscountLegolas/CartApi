using DotNetCore_Api.EfCore.Models;
using System.Collections.Generic;

namespace DotNetCore_Api.Models.Resources
{
    public class FilterResource
    {
        public string ResourceName { get; set; }
        public List<SeçenekResource> Seçenekler { get; set; }
        public List<Product> FilterProducts(List<Product> products)
        {
            foreach (var item in Seçenekler)
            {
                products = item.ApplySeçenek(products);
            }
            return products;
        }
    }
}