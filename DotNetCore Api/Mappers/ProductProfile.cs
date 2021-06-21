using AutoMapper;
using DotNetCore_Api.EfCore.Models;
using DotNetCore_Api.Models;
using DotNetCore_Api.Models.RequestModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetCore_Api.Mappers
{
    public class ProductProfile:Profile
    {
        public ProductProfile()
        {
            CreateMap<Product, ProductViewModel>().ForMember(x => x.Kategoriİsmi, opt => opt.MapFrom(a => a.Kategori.Kategoriİsmi)).ForMember(x => x.Markaİsmi, opt => opt.MapFrom(a => a.Marka.Markaİsmi));
            CreateMap<ProductViewModel, Product>();
            CreateMap<AddProductRequestDto, Product>();
            CreateMap<UpdateProductDto, Product>();
        }
    }
}
