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
    public class FavoriteRepository : IFavoriteRepo
    {
        private CartDbcontext _dbcontext;
        public FavoriteRepository(CartDbcontext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public List<Product> AddandRemoveFavori(int userıd, int productıd)
        {
            if (!_dbcontext.Favoris.Any(x => x.ProductId == productıd && x.UserId == userıd))
            {
                Favori favori = new Favori() { UserId = userıd, ProductId = productıd };
                _dbcontext.Favoris.Add(favori);
                _dbcontext.SaveChanges();
            }
            else
            {
                var product = _dbcontext.Favoris.Where(x => x.ProductId == productıd && x.UserId == userıd);
                _dbcontext.Favoris.RemoveRange(product);
                _dbcontext.SaveChanges();
            }
            var products = new List<Product>();
            _dbcontext.Users.Include(x => x.Favoriler).First(x => x.UserId == userıd).Favoriler.ToList().ForEach(x =>
            {
                products.Add(x.Product);
            });
            return products;
        }
        public List<Product> GetFavoris(int userıd)
        {
            var products = new List<Product>();
            _dbcontext.Users.Include(x => x.Favoriler.Select(a => a.Product)).First(x => x.UserId == userıd).Favoriler.ToList().ForEach(x =>
            {
                products.Add(x.Product);
            });
            return products;
        }
    }
}
