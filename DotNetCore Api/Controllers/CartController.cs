using AutoMapper;
using DotNetCore_Api.ServiceModel.Abstract.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetCore_Api.Controllers
{
    [Route("[controller]")]
    [Authorize]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly ICartService _service;
        private readonly IMapper _mapper;
        private readonly ILogger _loger;
        public CartController(IMapper mapper,ILogger<CartController> logger,ICartService service)
        {
            _service = service;
            _loger = logger;
            _mapper = mapper;
        }
        [HttpGet("Add/{productıd}")]
        public IActionResult AddToCart(int productıd)
        {
            var userıd = Convert.ToInt32(HttpContext.User.Claims.First(x => x.Type == "UserId").Value);
            var cart = _service.AddProductToCart(userıd, productıd);
            return Ok(cart);
        }
        [HttpGet("Remove/{productıd}")]
        public IActionResult RemoveFromCart(int productıd)
        {
            var userıd = Convert.ToInt32(HttpContext.User.Claims.First(x => x.Type == "UserId").Value);
            var cart = _service.RemoveProductFromCart(userıd, productıd);
            return Ok(cart);
        }
        [HttpGet("Decrease/{productıd}")]
        public IActionResult DecreaseQuantity(int productıd)
        {
            var userıd = Convert.ToInt32(HttpContext.User.Claims.First(x => x.Type == "UserId").Value);
            var cart = _service.DecreaseQuantity(userıd, productıd);
            return Ok(cart);
        }
    }
}
