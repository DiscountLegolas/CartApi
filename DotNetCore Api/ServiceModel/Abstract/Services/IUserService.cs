using DotNetCore_Api.EfCore.Models;
using DotNetCore_Api.Models.ResponseModels;
using DotNetCore_Api.Repotutories.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetCore_Api.ServiceModel.Abstract
{
    public interface IUserService
    {
        List<Product> AddandRemoveFavori(int userıd, int productıd);
        List<Product> GetFavoris(int userıd);
        AddUserResponseDto Register(User user);
        LoginUserResponseDto Login(User user);
        List<Kategori> GetRecomendedCategories(int userıd);
        List<Product> FilterProductList(List<Filter> filters, int categoryıd);
    }
}
