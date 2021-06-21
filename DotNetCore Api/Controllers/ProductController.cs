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
            var product = _service.GetProducts();
            var pvms = _mapper.Map<IList<Product>, List<ProductViewModel>>(product);
            return Ok(pvms);
        }
        [HttpGet("GetProduct/{id}")]
        public IActionResult GetProduct(int id)
        {
            var product = _service.GetProduct(id);
            if (product==null)
            {
                return NotFound("Aradığınız Ürün Bulunamadı");
            }
            var pvm = _mapper.Map<ProductViewModel>(product);
            return Ok(pvm);
        }
        [HttpPut("UpdateProduct")]
        public IActionResult UpdateProduct([FromBody] UpdateProductDto add)
        {
            var product = _mapper.Map<UpdateProductDto, Product>(add);
            var prdct = _service.UpdateProduct(product);
            var prdctvm = _mapper.Map<ProductViewModel>(prdct);
            return Ok(prdctvm);
        }
        [HttpPost("AddProduct")]
        public IActionResult AddProduct([FromBody] AddProductRequestDto add)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.Values.SelectMany(x=>x.Errors.Select(a=>a.ErrorMessage)).ToList());
            }

        }
    }
}
