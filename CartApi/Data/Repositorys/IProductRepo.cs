using CartApi.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CartApi.Data
{
    public interface IProductRepo
    {
        IList<ProductViewModel> GetProducts();
        ProductViewModel GetProduct(int id);
    }
    public class ProductRepo : IProductRepo
    {
        public ProductViewModel GetProduct(int id)
        {
            ProductViewModel product = null;
            using (CartContext context = new Data.CartContext())
            {
                if (context.Products.Any(X => X.ProductId == id))
                {
                    var a = context.Products.First(X => X.ProductId == id);
                    product = new ProductViewModel()
                    {
                        ProductId = a.ProductId,
                        Name = a.Name,
                        Description = a.Description,
                        Price = a.Price,
                    };
                }
            }
            return product;
        }

        public IList<ProductViewModel> GetProducts()
        {
            IList<ProductViewModel> products = null;
            using (Data.CartContext context = new Data.CartContext())
            {
                products = context.Products.Select(x => new ProductViewModel()
                {
                    ProductId = x.ProductId,
                    Name = x.Name,
                    Description = x.Description,
                    Price = x.Price
                }).ToList();
            }
            return products;
        }
    }
}
