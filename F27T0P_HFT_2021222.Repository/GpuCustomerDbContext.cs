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
            modelBuilder.Entity<Brand>(brand => brand.HasOne(brand => brand.GpuType)
                                                     .WithMany(gpu => gpu.Brands)
                                                     .HasForeignKey(brand => brand.GpuTypeId)
                                                     .OnDelete(DeleteBehavior.ClientSetNull));

            modelBuilder.Entity<GpuType>(gpu => gpu.HasOne(gpu => gpu.Customer)
                                                   .WithMany(customer => customer.BoughtCards)
                                                   .HasForeignKey(gpu => gpu.CustomerId)
                                                   .OnDelete(DeleteBehavior.ClientSetNull));

            var brands = new List<Brand>()
            {
                new Brand(){Name = "ASUS", GpuTypeId = 1},
                new Brand(){Name = "PALIT", GpuTypeId = 1},
                new Brand(){Name = "GIGABYTE", GpuTypeId = 2},
                new Brand(){Name = "SAPPHIRE", GpuTypeId = 5},
                new Brand(){Name = "MSI", GpuTypeId = 3},
                new Brand(){Name = "ZOTAC", GpuTypeId = 4},
                new Brand(){Name = "NVIDIA", GpuTypeId = 6}
            };

            var gpuTypes = new List<GpuType>()
            {
                new GpuType(){Id = 1, Name = "RTX 3050",  BasePrice = 150000, CustomerId = 1},
                new GpuType(){Id = 2, Name = "RTX 3060",  BasePrice = 200000, CustomerId = 2},
                new GpuType(){Id = 3, Name = "RTX 3070",  BasePrice = 280000, CustomerId = 2},
                new GpuType(){Id = 4, Name = "RTX 3080",  BasePrice = 400000, CustomerId = 3},
                new GpuType(){Id = 5, Name = "RX 6800XT",  BasePrice = 500000, CustomerId = 3},
                new GpuType(){Id = 6, Name = "RTX 3090", BasePrice = 900000}
            };

            var customers = new List<Customer>()
            {
                new Customer(){Id = 1, Name = "Máté"},
                new Customer(){Id = 2, Name = "Pista"},
                new Customer(){Id = 3, Name = "Palkó"},
            };

            modelBuilder.Entity<Brand>().HasData(brands);
            modelBuilder.Entity<GpuType>().HasData(gpuTypes);
            modelBuilder.Entity<Customer>().HasData(customers);
        }
    }
}
