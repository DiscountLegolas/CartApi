using DotNetCore_Api.Models.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetCore_Api.Models.ResponseModels
{
    public class CartResponseDto
    {
        public double TotalPrice { get; set; }
        public IList<ProductDto> Products { get; set; }
    }
}
