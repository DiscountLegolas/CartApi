using DotNetCore_Api.EfCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetCore_Api.ServiceModel.Abstract.Services
{
    public interface ICategoryService
    {
        Kategori GetKategori(int kategoriıd);
        IList<Product> GetKategoriProducts(int kategoriıd);
        IList<Kategori> GetAllKategoris();
    }
}
