using DotNetCore_Api.EfCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetCore_Api.ServiceModel.Abstract.Repositorys
{
    public interface ICategoryRepository
    {
        IList<Kategori> GetAllKategoriler();
        IList<Product> GetKategoriProducts(int categoriıd);
        IList<Kategori> GetUsersMostUsedKategoris(int userıd);
        Kategori GetKategori(int kategoriıd);
    }
}
