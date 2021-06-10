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
    public interface ICartRepo
    {
        List<ProductViewModel> GetRecomendations(int userid);
        CartViewModel GetProductsıncart(int id);
        void AddItemToCart(AddProductToCartVM product);
    }
    public class CartRepo : ICartRepo
    {
        public void AddItemToCart(AddProductToCartVM product)
        {
            using (var a=new CartContext())
            {
                var user = a.Users.First(x => x.UserId == product.UserId);
                if (user.Cart.ProductIncarts.Any(x=>x.ProductId==product.ProductId))
                {
                    user.Cart.ProductIncarts.First(x => x.ProductId == product.ProductId).Quantity++;
                }
                else
                {
                    a.ProductIncarts.Add(new Models.ProductIncart()
                    {
                        CartId = user.Cart.CartId,
                        ProductId = product.ProductId,
                        Quantity = 1,
                        Id = new Random().Next()
                    });
                }
                a.SaveChanges();
            }
        }
        public CartViewModel GetProductsıncart(int userid)
        {
            List<ProductViewModel> products = null;
            using (var context=new CartContext())
            {
                var cart = context.Users.First(x => x.UserId == userid).Cart;
                products = cart.ProductIncarts.Select(x => new ProductViewModel()
                {
                    ProductId = x.Product.ProductId,
                    Name = x.Product.Name,
                    Description = x.Product.Description,
                    Price = x.Product.Price*x.Quantity,
                }).ToList();
            }
            CartViewModel cartViewModel = new CartViewModel() { ProductsInCart = products };
            double totalprice = 0;
            foreach (var item in cartViewModel.ProductsInCart)
            {
                totalprice += item.Price;
            }
            cartViewModel.TotalPrice = totalprice;
            return cartViewModel;
        }
        public List<ProductViewModel> GetRecomendations(int userid)
        {
            List<KategoriPopulerlik> usedcategories = new List<KategoriPopulerlik>();
            List<ProductViewModel> RECOMENDATİONS = new List<ProductViewModel>();
            using (CartContext context=new CartContext())
            {
                var cart = context.Users.Single(x => x.UserId == userid).Cart;
                foreach (var item in cart.ProductIncarts)
                {
                    var category = item.Product.Kategori;
                    if (usedcategories.Any(x=>x.Kategori.KategoriId==category.KategoriId))
                    {
                        usedcategories.First(x => x.Kategori.KategoriId == category.KategoriId).populerlik++;
                    }
                    else
                    {
                        usedcategories.Add(new KategoriPopulerlik() { Kategori = category, populerlik = 1 });
                    }
                }
                var mostusedcategories = usedcategories.OrderByDescending(x => x.populerlik).Take(2);
                foreach (var item in mostusedcategories)
                {
                    var mostaddeditemsincategory = context.Products.Where(x => x.KategoriId == item.Kategori.KategoriId).OrderByDescending(A => A.CartsThatHavaProduct.Count).Take(5).Select(X => new ProductViewModel()
                    {
                        ProductId = X.ProductId,
                        Name = X.Name,
                        Description = X.Description,
                        Price = X.Price,
                        Kategoriismi = item.Kategori.Kategoriİsmi
                    });
                    RECOMENDATİONS.AddRange(mostaddeditemsincategory);
                }
            }
            return RECOMENDATİONS;
        }
    }
}
