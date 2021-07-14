using DotNetCore_Api.EfCore.Models;
using DotNetCore_Api.Repotutories.Abstract;
using DotNetCore_Api.Servicesandrepostitories.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetCore_Api.ServiceModel.Concrete
{
    public class ProductService : IProductService
    {
        private readonly IProductRepo _productrepo;
        public ProductService(IProductRepo repo)
        {
            _productrepo = repo;
        }

        public void DeleteProduct(int id)
        {
            _productrepo.DeleteProduct(id);
        }

        public List<Product> GetMostEconomicProducts()
        {
            var products = _productrepo.GetProducts();
            return products.OrderBy(x => x.Price / x.OriginalPrice).TakeWhile(x=>(x.Price/x.OriginalPrice)<0.7).ToList();
        }

        public Product GetProduct(int id)
        {
            return _productrepo.GetProduct(id);
        }

        public IList<Product> GetProducts()
        {
            var products = _productrepo.GetProducts();
            return products;
        }

        public Product UpdateProduct(Product updatemodel)
        {
            var product= _productrepo.UpdateProduct(updatemodel);
            return product;
        }
    }
}
