using AutoMapper;
using DotNetCore_Api.EfCore.Models;
using DotNetCore_Api.Models;
using DotNetCore_Api.Models.RequestModels;
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
            return Ok(products);
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
    }
}
