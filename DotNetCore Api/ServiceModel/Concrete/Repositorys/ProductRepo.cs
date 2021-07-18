using DotNetCore_Api.Repotutories.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using DotNetCore_Api.Models;
using DotNetCore_Api.EfCore;
using DotNetCore_Api.EfCore.Models;

namespace DotNetCore_Api.Repotutories.Concrete
{
    public class ProductRepo : IProductRepo
    {
        private List<Product> _products;
        private CartDbcontext _context;
        public ProductRepo(CartDbcontext context)
        {
            context.Database.EnsureCreated();
            _context = context;
            _products = _context.Products.Include(x => x.Kategori).Include(x => x.Marka).Include(x=>x.Özelliks).ThenInclude(x=>x.Özellik).ToList();
        }
        public void AddProduct(Product product)
        {
            _context.Products.Add(product);
            _context.SaveChanges();
        }

        public List<Product> ApplyFiltersToProducts(IList<Product> products, List<Filter> filters)
        {
            foreach (var item in filters)
            {
                //products = item.GetFilteredProducts(products.ToList());
            }
            return products.ToList();
        }

        public void DeleteProduct(int id)
        {
            var product = _context.Products.First(x => x.ProductId == id);
            _context.Products.Remove(product);
        }

        public Product GetProduct(int id)
        {
            Product product = null;
            if (_products.Any(X => X.ProductId == id))
            {
                product = _products.FirstOrDefault(X => X.ProductId == id);
            }
            return product;
        }

        public IList<Product> GetProducts()
        {
            var products = this._products;
            return products;
        }
        public Product UpdateProduct(Product updatedatas)
        {
            var productindb = _context.Products.Include(x => x.Kategori).Include(x => x.Marka).First(x => x.ProductId == updatedatas.ProductId);
            foreach (var item in updatedatas.GetType().GetProperties())
            {
                if (item.GetValue(updatedatas,null)!=null)
                {
                    var value = item.GetValue(updatedatas, null);
                    var dbproperty = productindb.GetType().GetProperty(item.Name);
                    dbproperty.SetValue(productindb, value);
                }
            }
            _context.SaveChanges();
            return productindb;
        }
    }
}
