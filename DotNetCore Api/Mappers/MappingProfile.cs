using AutoMapper;
using DotNetCore_Api.EfCore.Models;
using DotNetCore_Api.Models;
using DotNetCore_Api.Models.RequestModels;
using DotNetCore_Api.Models.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetCore_Api.Mappers
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<AddProductRequestDto, Product>();
            CreateMap<UpdateProductRequestDto, Product>();
            CreateMap<Product, ProductDto>();
            CreateMap<LoginRequestDto, User>().ForMember(x => x.Username, opt => opt.MapFrom(a => a.Username)).ForMember(x => x.Password, opt => opt.MapFrom(a => a.Password));
            CreateMap<Kategori, CategoryResource>().ForMember(x => x.ÜstKategori, opt => opt.MapFrom(a => a.ÜstKategori)).ForMember(x => x.AltKategoriler, opt => opt.MapFrom(a => a.AltKategoriler));
            CreateMap<Kategori, ÜstCategoryResource>();
            CreateMap<Kategori, AltCategoryResource>();
        }
    }
}
