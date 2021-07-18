using DotNetCore_Api.EfCore.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetCore_Api.EfCore
{
    public class CartDbcontext:DbContext
    {
        public CartDbcontext(DbContextOptions<CartDbcontext> options):base(options)
        {

        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<ProductIncart> ProductIncarts { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<HizmetVerir> HizmetVerirs { get; set; }
        public DbSet<Marka> Markas { get; set; }
        public DbSet<Kategori> Kategoris { get; set; }
        public DbSet<Favori> Favoris { get; set; }
        public DbSet<Özellik> Özelliks { get; set; }
        public DbSet<HasÖzellik> HasÖzelliks { get; set; }
        public DbSet<Filter> Filters { get; set; }
        public DbSet<AppliesTo> AppliesTos { get; set; }
        public DbSet<Seçenek> Seçenekler { get; set; }
    }
}
