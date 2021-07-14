using DotNetCore_Api.EfCore;
using DotNetCore_Api.EfCore.Models;
using DotNetCore_Api.ServiceModel.Abstract.Repositorys;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetCore_Api.ServiceModel.Concrete.Repositorys
{
    public class CartRepository : ICartRepository
    {
        private CartDbcontext _context;
        public CartRepository(CartDbcontext context)
        {
            _context = context;
        }
        public Cart AddToCart(int userid, int productıd)
        {
            if (_context.ProductIncarts.Any(X=>X.ProductId==productıd&&X.CartId==userid))
            {
                var a = _context.ProductIncarts.First(X => X.ProductId == productıd && X.CartId == userid);
                a.Quantity++;
            }
            else
            {
                ProductIncart product = new ProductIncart() { Quantity = 1, ProductId = productıd, CartId = userid };
                _context.ProductIncarts.Add(product);
            }
            _context.SaveChanges();
            var cart = _context.Carts.Include(x => x.ProductIncarts).ThenInclude(a=>a.Product).First(x => x.CartId == userid);
            return cart;
        }

        public Cart DecreaseQuantity(int userıd, int productıd)
        {
            var a = _context.ProductIncarts.First(X => X.ProductId == productıd && X.CartId == userıd);
            a.Quantity--;
            _context.SaveChanges();
            var cart = _context.Carts.Include(x => x.ProductIncarts).ThenInclude(y => y.Product).First(x => x.CartId == userıd);
            return cart;
        }

        public Cart GetCartInfo(int userıd)
        {
            var cart = _context.Carts.Include(x => x.ProductIncarts).ThenInclude(y => y.Product).First(x => x.CartId == userıd);
            return cart;
        }

        public Cart RemoveFromCart(int userıd, int productıd)
        {
            var prodıncart = _context.ProductIncarts.First(x => x.CartId == userıd && x.ProductId == productıd);
            _context.ProductIncarts.Remove(prodıncart);
            _context.SaveChanges();
            return _context.Carts.Include(x => x.ProductIncarts).ThenInclude(y=>y.Product).First(x => x.CartId == userıd);
        }
    }
}
