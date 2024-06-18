using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProductStore.Models;

namespace ProductStore
{
    public class AppDbContext : DbContext
    {
       public AppDbContext(DbContextOptions<AppDbContext> optiond): base(optiond) { }   

        public DbSet<Product> Products { get; set; }

    }
}
