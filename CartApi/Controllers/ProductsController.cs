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
    public class ProductsController : ApiController
    {
        private IProductRepo _repo;
        public ProductsController(IProductRepo repo)
        {
            _repo = repo;
        }
        [HttpGet]
        public IHttpActionResult GetAllProducts()
        {
            IList<ProductViewModel> products = _repo.GetProducts();
            if (products.Count == 0)
            {
                return NotFound();
            }
            return Json(products);
        }
        [HttpGet]
        public IHttpActionResult GetProduct(int id)
        {
            ProductViewModel product = _repo.GetProduct(id);
            if (product==null)
            {
                HttpResponseMessage message = new HttpResponseMessage(HttpStatusCode.NotFound) { Content=new StringContent("Ürün Bulunamadı")};
                return ResponseMessage(message);
            }
            return Json(product);
        }
    }
}
