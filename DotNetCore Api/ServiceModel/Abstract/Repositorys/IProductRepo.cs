using DotNetCore_Api.EfCore.Models;
using DotNetCore_Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetCore_Api.Repotutories.Abstract
{
    public interface IProductRepo
    {

        void DeleteProduct(int id);
        Product UpdateProduct(Product producttoupdate);
        void AddProduct(Product add);
        IList<Product> GetProducts();
        Product GetProduct(int id);
    }
}
