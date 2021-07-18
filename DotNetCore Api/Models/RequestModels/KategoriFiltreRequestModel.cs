using DotNetCore_Api.Models.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetCore_Api.Models.RequestModels
{
    public class KategoriFiltreRequestModel
    {
        public string[] Kategoriler { get; set; }
        public ProductDto[] Products { get; set; }
    }
}
