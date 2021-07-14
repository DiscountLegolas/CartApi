using DotNetCore_Api.EfCore.Models;
using DotNetCore_Api.ServiceModel.Abstract.Repositorys;
using DotNetCore_Api.ServiceModel.Abstract.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetCore_Api.ServiceModel.Concrete.Services
{
    public class CategoryService : ICategoryService
    {
        private ICategoryRepository _categoryRepository;
        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public IList<Kategori> GetAllKategoris()
        {
            var cats = _categoryRepository.GetAllKategoriler().ToList();
            return cats;
        }

        public Kategori GetKategori(int kategoriıd)
        {
            var kategori = _categoryRepository.GetKategori(kategoriıd);
            return kategori;
        }

        public IList<Product> GetKategoriProducts(int kategoriıd)
        {
            return _categoryRepository.GetKategoriProducts(kategoriıd);
        }
    }
}
