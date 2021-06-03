using CartApi.Data.Models;
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
            Database.SetInitializer<CartContext>(new CartDbİnit());
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<ProductIncart> ProductIncarts { get; set; }
        public DbSet<User> Users { get; set; }
    }
    public class CartDbİnit:DropCreateDatabaseIfModelChanges<CartContext>
    {
        protected override void Seed(CartContext context)
        {
            Product product = new Product() { ProductId = new Random().Next(), Name = "TestName", Description = "Description", Price = 20.1646 };
            context.Products.Add(product);
            User user = new User() { UserId = new Random().Next(), Username = "faff", Password = "Pass" };
            Cart cart= new Cart() { CartId = user.UserId};
            context.Users.Add(user);
            context.Carts.Add(cart);
            context.SaveChanges();
            base.Seed(context);
        }
    }
}