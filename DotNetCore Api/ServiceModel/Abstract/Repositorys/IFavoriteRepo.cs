using DotNetCore_Api.EfCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetCore_Api.ServiceModel.Abstract.Repositorys
{
    public interface IFavoriteRepo
    {
        List<Product> AddandRemoveFavori(int userıd, int productıd);
        List<Product> GetFavoris(int userıd);
    }
}
