using DotNetCore_Api.EfCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetCore_Api.Servicesandrepostitories.Abstract
{
    public interface IProductService
    {
        void DeleteProduct(int id);
        IList<Product> GetProducts();
        Product UpdateProduct(Product updatemodel);
        Product GetProduct(int id);
    }
}
