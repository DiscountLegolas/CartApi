using AutoMapper;
using DotNetCore_Api.EfCore.Models;
using DotNetCore_Api.Models;
using DotNetCore_Api.Models.RequestModels;
using DotNetCore_Api.Models.Resources;
using DotNetCore_Api.Servicesandrepostitories.Abstract;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetCore_Api.Controllers
{
    [Route("product")]

    public class ProductController : Controller
    {
        private readonly IMapper _mapper;
        private readonly ILogger _loger;
        private readonly IProductService _service;
        public ProductController(ILogger<ProductController> logger,IMapper mapper,IProductService service)
        {
            _loger = logger;
            _mapper = mapper;
            _service = service;
        }
        [HttpGet("GetProducts")]
        public IActionResult GetAllProducts()
        {
            var products = _service.GetProducts();
            var productsdto = _mapper.Map<IList<Product>, List<ProductDto>>(products);
            return Ok(productsdto);
        }
        [HttpGet("GetProduct/{id}")]
        public IActionResult GetProduct(int id)
        {
            var product = _service.GetProduct(id);
            if (product==null)
            {
                return NotFound("Aradığınız Ürün Bulunamadı");
            }
            return Ok(product);
        }
        [HttpPut("UpdateProduct")]
        public IActionResult UpdateProduct([FromBody] UpdateProductRequestDto add)
        {
            var product = _mapper.Map<UpdateProductRequestDto, Product>(add);
            var prdct = _service.UpdateProduct(product);
            return Ok(prdct);
        }
        [HttpPost("AddProduct")]
        public IActionResult AddProduct([FromBody] AddProductRequestDto add)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.Values.SelectMany(x=>x.Errors.Select(a=>a.ErrorMessage)).ToList());
            }
            else
            {
                return Ok();
            }
        }
        [HttpPost("Filter/Marka")]
        public IActionResult MarkaFiltre([FromBody] MarkaFilterRequestDto markaFilterRequest)
        {
            var products = new List<Product>();
            foreach (var item in _service.GetProducts())
            {
                if (markaFilterRequest.Products.Any(x=>x.ProductId==item.ProductId))
                {
                    products.Add(item);
                }
            }
            foreach (var item in markaFilterRequest.Markalar)
            {
                products = products.Where(x => x.Marka.Markaİsmi == item).ToList();
            }
            var productsdto = _mapper.Map<List<Product>, List<ProductDto>>(products);
            return Ok(productsdto);
        }
        [HttpPost("Filter/Kategori")]
        public IActionResult KategoriFiltre([FromBody] KategoriFiltreRequestModel kategoriFilterRequest)
        {
            var products = new List<Product>();
            foreach (var item in _service.GetProducts())
            {
                if (kategoriFilterRequest.Products.Any(x => x.Name == item.Name))
                {
                    products.Add(item);
                }
            }
            foreach (var item in kategoriFilterRequest.Kategoriler)
            {
                products = products.Where(x => x.Kategori.Kategoriİsmi == item).ToList();
            }
            var productsdto = _mapper.Map<List<Product>, List<ProductDto>>(products);
            return Ok(productsdto);
        }
        [HttpPost("Filter/Price")]
        public IActionResult PriceFilter([FromBody] PriceFilterRequestDto priceFilterRequest)
        {
            return Ok(priceFilterRequest.Products.Where(x => x.Price <= priceFilterRequest.MaxPrice && x.Price >= priceFilterRequest.MinPrice));
        }
        [HttpPost("Filter")]
        public IActionResult OtherFilters([FromBody] OtherFiltersRequestDto otherFiltersRequest)
        {
            var products = new List<Product>();
            foreach (var item in _service.GetProducts())
            {
                if (otherFiltersRequest.Products.Any(x => x.Name == item.Name))
                {
                    products.Add(item);
                }
            }
            foreach (var item in otherFiltersRequest.Filters)
            {
                products = item.FilterProducts(products);
            }
            var productsdto = _mapper.Map<List<Product>, List<ProductDto>>(products);
            return Ok(productsdto);
        }
    }
}
