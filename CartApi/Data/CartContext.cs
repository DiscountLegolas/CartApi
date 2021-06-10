using CartApi.Data.Models;
using CartApi.Migrations;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CartApi.Data
{
    public class CartContext:DbContext
    {
        public CartContext():base("name=CartDbConnectionString")
        {
            Database.SetInitializer<CartContext>(new MigrateDatabaseToLatestVersion<CartContext,Configuration>());
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<ProductIncart> ProductIncarts { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<HizmetVerir> HizmetVerirs { get; set; }
        public DbSet<Marka> Markas { get; set; }
        public DbSet<Kategori> Kategoris { get; set; }
    }

}