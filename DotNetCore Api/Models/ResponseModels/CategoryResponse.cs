using DotNetCore_Api.Models.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetCore_Api.Models.ResponseModels
{
    public class CategoryResponse
    {
        public List<CategoryResource> Categories { get; set; }
        public string Message { get; set; }
    }
}
