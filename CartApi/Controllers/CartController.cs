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
    [Authorize]
    [RoutePrefix("api/Cart")]
    public class CartController : ApiController
    {
        private ICartRepo _repo;
        public CartController(ICartRepo repo)
        {
            _repo = repo;
        }
        [HttpPost]
        [Route("AddItem")]
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
                HttpResponseMessage message = new HttpResponseMessage(HttpStatusCode.NotFound) { Content = new StringContent("Sepette Ürün Yok") };
                return ResponseMessage(message);
            }
            return Json(a);
        }
        [HttpGet]
        [Route("Recomendations/{id}")]
        public IHttpActionResult GetRecomendations(int id)
        {
            var reco = _repo.GetRecomendations(id);
            return Ok(reco);
        }
    }
}
