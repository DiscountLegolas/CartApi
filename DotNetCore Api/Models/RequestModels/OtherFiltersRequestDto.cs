using DotNetCore_Api.Models.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetCore_Api.Models.RequestModels
{
    public class OtherFiltersRequestDto
    {
        public List<FilterResource> Filters { get; set; }
        public List<ProductDto> Products { get; set; }
    }
}
