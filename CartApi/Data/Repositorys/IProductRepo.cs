using CartApi.Data.Models;
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
        void DeleteProduct(int id);
        ProductViewModel UpdateProduct(UpdateProductViewModel update);
        void AddProduct(AddProductViewModel add);
        IList<ProductViewModel> GetProducts();
        ProductViewModel GetProduct(int id);
    }
    public class ProductRepo : IProductRepo
    {
        public void AddProduct(AddProductViewModel add)
        {
            using (CartContext context=new CartContext())
            {
                var product = new Product() { Name = add.Name, Description = add.Description, Price = add.Price, MarkaId = 1, KategoriId = 1 };
                context.Products.Add(product);
                context.SaveChanges();
                context.Dispose();
            }
        }

        public void DeleteProduct(int id)
        {
            using (CartContext context = new CartContext())
            {
                var producttodelete = context.Products.First(x => x.ProductId == id);
                context.Products.Remove(producttodelete);
                context.SaveChanges();
                context.Dispose();
            }
        }

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
                    Price = x.Price,
                    Kategoriismi=x.Kategori.Kategoriİsmi
                }).ToList();
            }
            return products;
        }

        public ProductViewModel UpdateProduct(UpdateProductViewModel update)
        {
            ProductViewModel productmodel = null;
            using (CartContext context = new CartContext())
            {
                var product = context.Products.First(x => x.ProductId == update.ProductId);
                foreach (var property in update.GetType().GetProperties())
                {
                    if (property.GetValue(update, null) != null)
                    {
                        foreach (var property1 in product.GetType().GetProperties())
                        {
                            if (property1.Name == property.Name)
                            {
                                var value = property.GetValue(update, null);
                                property1.SetValue(product, value);
                                break;
                            }
                        }
                    }
                }
                context.SaveChanges();
                var kategori = context.Kategoris.First(x => x.KategoriId == product.KategoriId).Kategoriİsmi;
                context.Dispose();
                productmodel = new ProductViewModel() { Name = product.Name, Description = product.Description,Price=product.Price,ProductId=product.ProductId,Kategoriismi=kategori };
            }
            return productmodel;
        }
    }
}
