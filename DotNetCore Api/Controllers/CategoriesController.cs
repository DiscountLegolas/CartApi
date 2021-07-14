using AutoMapper;
using DotNetCore_Api.EfCore.Models;
using DotNetCore_Api.Models;
using DotNetCore_Api.Models.Resources;
using DotNetCore_Api.Models.ResponseModels;
using DotNetCore_Api.ServiceModel.Abstract.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetCore_Api.Controllers
{
    [Route("Kategori")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private ICategoryService _categoryService;
        private ILogger _logger;
        private IMapper _mapper;
        private IMemoryCache _memoryCache;
        public CategoriesController(ICategoryService categoryService,ILogger<CategoriesController> logger,IMapper mapper,IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;
            _logger = logger;
            _mapper = mapper;
            _categoryService = categoryService;
        }
        [HttpGet("Kategori/{kategoriıd}")]
        public IActionResult GetCategory(int kategoriıd)
        {
            string key = "kategori" + kategoriıd.ToString();
            if (_memoryCache.TryGetValue(key,out CategoryResource category))
            {
                return Ok(category);
            }
            var kategori = _categoryService.GetKategori(kategoriıd);
            var kategoriresource = _mapper.Map<Kategori, CategoryResource>(kategori);
            MemoryCacheEntryOptions options = new MemoryCacheEntryOptions()
            {
                AbsoluteExpiration = DateTime.Now.AddMinutes(10),
                SlidingExpiration = TimeSpan.FromMinutes(2.5)
            };
            _memoryCache.Set(key, kategoriresource, options);
            return Ok(kategoriresource);
        }
        [HttpGet]
        public IActionResult GetCategories()
        {
            if (_memoryCache.TryGetValue("categories",out List<CategoryResource> kategoriler))
            {
                CategoryResponse categoryResponse = new CategoryResponse() { Message = "FromCache", Categories = kategoriler };
                return Ok(categoryResponse);
            }
            var list = _categoryService.GetAllKategoris();
            var listresource = _mapper.Map<IList<Kategori>, List<CategoryResource>>(list);
            CategoryResponse response = new CategoryResponse() { Message = "FromDb", Categories = listresource };
            MemoryCacheEntryOptions options = new MemoryCacheEntryOptions()
            {
                AbsoluteExpiration = DateTime.Now.AddMinutes(10),
                SlidingExpiration=TimeSpan.FromMinutes(2.5)
            };
            _memoryCache.Set("categories", listresource, options);
            return Ok(response);
        }
        [HttpGet("{categoryıd}")]
        public IActionResult GetCategoryProducts(int categoryıd)
        {
            var products= _categoryService.GetKategoriProducts(categoryıd);
            var productdtos = _mapper.Map<IList<Product>, List<ProductDto>>(products);
            return Ok(productdtos);
        }
    }
}
