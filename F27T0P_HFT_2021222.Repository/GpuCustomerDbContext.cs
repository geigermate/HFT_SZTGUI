using F27T0P_HFT_2021222.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace F27T0P_HFT_2021222.Repository
{
    public partial class GpuCustomerDbContext : DbContext
    {
        public virtual DbSet<Brand> Brands { get; set; }
        public virtual DbSet<GpuType> GpuTypes { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }

        public GpuCustomerDbContext()
        {
            this.Database.EnsureCreated();
        }

        public GpuCustomerDbContext(DbContextOptions<GpuCustomerDbContext> options) : base(options)
        {
            this.Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseInMemoryDatabase("féléves")
                              .UseLazyLoadingProxies();
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<GpuType>(gpu => gpu.HasOne(gpu => gpu.Brand)
            //                                       .WithMany(brand => brand.GpuTypes)
            //                                       .HasForeignKey(gpu => gpu.BrandId)
            //                                       .OnDelete(DeleteBehavior.ClientSetNull));

            modelBuilder.Entity<GpuType>(gpu => gpu.HasOne(gpu => gpu.Brand)
                                                   .WithMany(brand => brand.GpuTypes)
                                                   .HasForeignKey(gpu => gpu.BrandId)
                                                   .OnDelete(DeleteBehavior.ClientSetNull));

            modelBuilder.Entity<Brand>(brand => brand.HasOne(brand => brand.Customer)
                                                     .WithMany(customer => customer.BoughtCards)
                                                     .HasForeignKey(brand => brand.CustomerId)
                                                     .OnDelete(DeleteBehavior.ClientSetNull));

            //modelBuilder.Entity<Customer>(customer => customer.HasOne(customer => customer.Basket)
            //                                                  .WithMany(gpu => gpu.Customer));

            var gpuTypes = new List<GpuType>()
            {
                new GpuType(){Id = 1, Name = "RTX 3050",  BasePrice = 150000, BrandId = 1},
                new GpuType(){Id = 2, Name = "RTX 3060",  BasePrice = 200000, BrandId = 1},
                new GpuType(){Id = 3, Name = "RTX 3070",  BasePrice = 280000, BrandId = 1},
                new GpuType(){Id = 4, Name = "RTX 3080",  BasePrice = 400000, BrandId = 1},
                new GpuType(){Id = 5, Name = "RX 6800XT",  BasePrice = 500000, BrandId = 2},
            };

            var brands = new List<Brand>()
            {
                new Brand(){Id = 1, Name = "NVIDIA", CustomerId = 1},
                new Brand(){Id = 2, Name = "AMD", CustomerId = 2},

            };

            var customers = new List<Customer>()
            {
                new Customer(){Id = 1, Name = "Máté"},
                new Customer(){Id = 2, Name = "Pista"},
                new Customer(){Id = 3, Name = "Julcsi"},
            };
        }
    }
}
