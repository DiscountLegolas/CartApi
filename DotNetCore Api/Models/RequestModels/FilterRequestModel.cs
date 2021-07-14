using DotNetCore_Api.EfCore.Models;
using DotNetCore_Api.Models.Resources;
using DotNetCore_Api.Repotutories.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetCore_Api.Models.RequestModels
{
    public class FilterRequestModel
    {
        public List<Filter> Filters { get; set; }
    }
}
