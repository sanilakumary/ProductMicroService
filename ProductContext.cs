using Microsoft.EntityFrameworkCore;
using ProductMicroService.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductMicroService.DBContexts
{
    public class ProductContext : DbContext
    {
        public ProductContext(DbContextOptions<ProductContext> options) :base(options)
        {

        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category
                {
                    Id=1,
                    Name="Electronics",
                    Description ="Electronic Items",
                },
               new Category {
                Id=2,
                Name ="Clothes",
                Description = "Dresses",
                },
               new Category
               {
                   Id=3,
                   Name = "Grocery",
                   Description ="Grocery Items",
               }
               );
            modelBuilder.Entity<Product>().HasData(
                new Product
                {
                    Id =1,
                    Name ="IPhone",
                    Description ="Apple Mobile Phone",
                    Price = 40000,
                    CategoryId =1,
                },
                new Product
                {
                    Id = 2,
                    Name = "Suit",
                    Description = "Raymond Suit",
                    Price = 10000,
                    CategoryId = 2,
                },
                new Product
                {
                    Id = 3,
                    Name = "Rice",
                    Description = "Nirapara Whole Rice",
                    Price = 100,
                    CategoryId = 3,
                }
                );
        }
    }
}
