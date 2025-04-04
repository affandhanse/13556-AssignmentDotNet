using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EcommerceApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace EcommerceApp.Infrastructure.Context
{
    public class ECommerceDbContext : DbContext
    {
        public ECommerceDbContext(DbContextOptions<ECommerceDbContext> options)
            : base(options)
        {
        }
        

        public DbSet<Product> Products { get; set; }

        public DbSet<ProductCategory> ProductCategories { get; set; }

        public DbSet<Orders> Orders { get; set; }
        public DbSet<CartItem> CartItems { get; set; }

        public DbSet<OrderItem> OrderItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Product>()
                .Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(100);

            modelBuilder.Entity<Product>()
                .Property(p => p.Price)
                .IsRequired(); 

            modelBuilder.Entity<Product>()
                .Property(p => p.Stock)
                .IsRequired();

            modelBuilder.Entity<Product>()
            .Property(p => p.PictureUrl)
            .IsRequired(false);

            modelBuilder.Entity<ProductCategory>()
                .Property(c => c.Name)
                .IsRequired()
                .HasMaxLength(100); 

            modelBuilder.Entity<ProductCategory>()
                .Property(c => c.Description)
                .HasMaxLength(500);


        }
    }
}