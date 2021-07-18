using DotNetCore_Api.Models.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetCore_Api.Models.RequestModels
{
    public class PriceFilterRequestDto
    {
        public double MaxPrice { get; set; }
        public double MinPrice { get; set; }
        public List<ProductDto> Products { get; set; }
    }
}
