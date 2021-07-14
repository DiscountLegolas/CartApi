using DotNetCore_Api.EfCore;
using DotNetCore_Api.EfCore.Models;
using DotNetCore_Api.ServiceModel.Abstract.Repositorys;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetCore_Api.ServiceModel.Concrete.Repositorys
{
    public class CategoryRepository : ICategoryRepository
    {
        private CartDbcontext _context;
        public CategoryRepository(CartDbcontext context)
        {
            _context = context;
        }
        public IList<Kategori> GetAllKategoriler()
        {
            return _context.Kategoris.Include(x=>x.ÜstKategori).Include(x=>x.AltKategoriler).ToList();
        }

        public Kategori GetKategori(int kategoriıd)
        {
            var list = _context.Kategoris.Include(x => x.ÜstKategori).Include(x => x.AltKategoriler).ToList();
            var kategori = list.First(x => x.KategoriId == kategoriıd);
            return kategori;
        }

        public IList<Product> GetKategoriProducts(int categoriıd)
        {
            var ürünleroncategory = new List<Product>();
            var category = _context.Kategoris.Include(x=>x.ProductsOnCategory).Include(x=>x.AltKategoriler).First(x => x.KategoriId == categoriıd);
            List<Product> GetÜrünler(Kategori kategori)
            {
                var list = new List<Product>();
                if (kategori.AltKategoriler.Count==0)
                {
                    return _context.Kategoris.Include(x => x.ProductsOnCategory).First(x => x.KategoriId == kategori.KategoriId).ProductsOnCategory.ToList();
                }
                else
                {
                    list.AddRange(kategori.ProductsOnCategory);
                    foreach (var item in kategori.AltKategoriler)
                    {
                        var product = _context.Kategoris.Include(x=>x.ProductsOnCategory).Include(x => x.AltKategoriler).First(x => x.KategoriId == item.KategoriId);
                        list.AddRange(GetÜrünler(product));
                    }
                    return list;
                }
            }
            return GetÜrünler(category);
        }

        public IList<Kategori> GetUsersMostUsedKategoris(int userıd)
        {
            var cartproducts = new List<Product>();
            var categories = new List<KategoriPopuler>();
            _context.Carts.Include(x => x.ProductIncarts).First(X => X.CartId == userıd).ProductIncarts.ToList().ForEach(x => { cartproducts.Add(x.Product); });
            _context.Users.Include(x => x.Favoriler).First(X => X.UserId == userıd).Favoriler.ToList().ForEach(x => { cartproducts.Add(x.Product); });
            int kategoripopularity(int categoryıd)
            {
                int popularity = cartproducts.Where(x => x.KategoriId == categoryıd).Count();
                return popularity;
            }
            _context.Kategoris.ToList().ForEach(x => { categories.Add(new KategoriPopuler() { Kategori = x, Popularity = kategoripopularity(x.KategoriId) }); });
            var kategoriler = new List<Kategori>();
            categories.OrderByDescending(x => x.Popularity).Take(20).ToList().ForEach(x => { kategoriler.Add(x.Kategori); });
            return kategoriler;
        }
        private class KategoriPopuler
        {
            public int Popularity { get; set; }
            public Kategori Kategori { get; set; }
        }
    }
}
