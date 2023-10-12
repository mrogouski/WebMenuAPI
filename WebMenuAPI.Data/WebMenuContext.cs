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
            Database.EnsureCreated();
        }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<User> Users { get; set; }

    }
}
