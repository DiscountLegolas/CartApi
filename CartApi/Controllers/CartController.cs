using CartApi.Data;
using CartApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CartApi.Controllers
{
    public class CartController : ApiController
    {
        private ICartRepo _repo;
        public CartController(ICartRepo repo)
        {
            _repo = repo;
        }
        [HttpPost]
        public IHttpActionResult PostProductToCart(AddProductToCartVM productIncart)
        {
            _repo.AddItemToCart(productIncart);
            return Ok();
        }
        [HttpGet]
        public IHttpActionResult GetItemsInCart(int id)
        {
            var a = _repo.GetProductsıncart(id);
            if (a.ProductsInCart.Count==0)
            {
                return Ok<String>("Sepette Ürün Yok");
            }
            return Ok(a);
        }
    }
}
