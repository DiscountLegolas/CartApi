using AutoMapper;
using DotNetCore_Api.EfCore.Models;
using DotNetCore_Api.Models;
using DotNetCore_Api.Models.RequestModels;
using DotNetCore_Api.Models.Resources;
using DotNetCore_Api.Models.ResponseModels;
using DotNetCore_Api.Repotutories.Abstract;
using DotNetCore_Api.ServiceModel.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace DotNetCore_Api.Controllers
{
    [Route("User")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IConfiguration _configuration;
        private readonly IMapper _mapper;
        private readonly ILogger _loger;
        private readonly IUserService _service;
        public UserController(IMapper mapper, ILogger<UserController> logger, IUserService service,IConfiguration configuration)
        {
            _mapper = mapper;
            _configuration = configuration;
            _loger = logger;
            _service = service;
        }
        [Authorize]
        [HttpGet("{userıd}/{productıd}")]
        public IActionResult AddandRemoveFavorite(int userıd,int productıd)
        {
            var userrole = HttpContext.User.Claims.First(x => x.Type == "Role").Value;
            if (userrole=="Kullanıcı"||userrole=="Admin")
            {
                var products = _service.AddandRemoveFavori(userıd, productıd);
                var productdtos = _mapper.Map<List<Product>, List<ProductDto>>(products);
                return Ok(productdtos);
            }
            else
            {
                return Forbid();
            }
        }
        [HttpPost("Filter/{catıd}")]
        public IActionResult Filter(FilterRequestModel filters,int catıd)
        {
            var filtersr = filters.Filters;
            var filtpproducts = _service.FilterProductList(filtersr, catıd);
            var filtproddtos = _mapper.Map<List<Product>, List<ProductDto>>(filtpproducts);
            return Ok(filtproddtos);
        }
        [HttpPost("Login")]
        public IActionResult Login(LoginRequestDto login)
        {
            if (ModelState.IsValid)
            {
                var user = _mapper.Map<LoginRequestDto, User>(login);
                var response = _service.Login(user);
                if (response.Message==null)
                {
                    var seckey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
                    var cred = new SigningCredentials(seckey, SecurityAlgorithms.HmacSha256);
                    var claimss = new[]
                    {
                        new Claim("UserId",response.User.UserId.ToString()),
                        new Claim("Role","Kullanıcı"),
                    };
                    var token = new JwtSecurityToken(_configuration["Jwt:Issuer"],
                             _configuration["Jwt:Issuer"],claimss,expires:DateTime.Now.AddMinutes(120),signingCredentials:cred);
                    response.Message="Token "+new JwtSecurityTokenHandler().WriteToken(token);
                }
                return Ok(response);
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
