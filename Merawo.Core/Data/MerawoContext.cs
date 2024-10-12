using Merawo.Core.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace Merawo.Core.Data
{
    public class MerawoContext : DbContext
    {
        public MerawoContext(DbContextOptions<MerawoContext> options) : base(options) { }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Purchase> Purchases { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Seed data for Brands
            modelBuilder.Entity<Brand>().HasData(
                new Brand { Id = 1, Title = "Renault", SellingCountry = "France" },
                new Brand { Id = 2, Title = "Ford", SellingCountry = "USA" }
            );

            // Seed data for Clients
            modelBuilder.Entity<Client>().HasData(
                new Client { Id = 1, FirstName = "Alexander", LastName = "Lugo", DocumentNumber = "9593278", DocumentType = Document.DNI },
                new Client { Id = 2, FirstName = "Mercky", LastName = "Velasquez", DocumentNumber = "14565987", DocumentType = Document.PASSPORT }
            );

            // Seed data for Purchases
            modelBuilder.Entity<Purchase>().HasData(
                new Purchase { Id = 1, Detail = "Purchase 1", Date = DateTime.Now, ClientId = 1 },
                new Purchase { Id = 2, Detail = "Purchase 2", Date = DateTime.Now, ClientId = 2 }
            );

            // Seed data for Products
            modelBuilder.Entity<Product>().HasData(
                new Product { Id = 1, Title = "Clio", Cost = 100.00, Stock = 50, IsActive = true, BrandId = 1, PurchaseId = 1 },
                new Product { Id = 2, Title = "Fiesta", Cost = 150.00, Stock = 30, IsActive = true, BrandId = 2, PurchaseId = 2 }
            );
        }
    }
}
