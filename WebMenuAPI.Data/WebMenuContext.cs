using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebMenuAPI.Data.Models;

namespace WebMenuAPI.Data
{
    public class WebMenuContext : DbContext
    {
        public WebMenuContext(DbContextOptions<WebMenuContext> options) : base(options)
        {
            Database.EnsureDeleted();
            Database.EnsureCreated();
        }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(new Category { Id = 1, Title = "Pizzas", Description = "Las Pizzas de Don Cangrejo" });
            
            var pizzas = new List<Product>();
            pizzas.Add(new Product { Id = 1, Title = "Calabresa", Description = "", Available = true, Price = 2000, ImageFilename = "", CategoryId = 1 });
            pizzas.Add(new Product { Id = 2, Title = "Napolitana", Description = "", Available = true, Price = 1900, ImageFilename = "", CategoryId = 1 });
            modelBuilder.Entity<Product>().HasData(pizzas);
            modelBuilder.Entity<User>().HasData(new User { Id = 1, Username = "admin", Password = "admin" });
            
            base.OnModelCreating(modelBuilder);
        }

    }
}
