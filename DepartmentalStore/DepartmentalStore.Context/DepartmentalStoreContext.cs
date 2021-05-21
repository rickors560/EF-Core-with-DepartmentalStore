using DepartmentalStore.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace DepartmentalStore.Context
{
    public class DepartmentalStoreContext : DbContext
    {
        public DbSet<Role> Role { get; set; }
        public DbSet<Address> Address { get; set; }
        public DbSet<Gender> Gender { get; set; }
        public DbSet<Staff> Staff { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<ProductCategory> ProductCategory { get; set; }
        public DbSet<Price> Price { get; set; }
        public DbSet<Inventory> Inventory { get; set; }
        public DbSet<Supplier> Supplier { get; set; }
        public DbSet<ProductSupplier> ProductSupplier { get; set; }
        public DbSet<Order> Order { get; set; }
        public DbSet<OrderDetail> OrderDetail { get; set; }

        public static readonly ILoggerFactory ConsoleLoggerFactory = LoggerFactory.Create(builder =>
        {
            builder
            .AddFilter((category, level) =>
                category == DbLoggerCategory.Database.Command.Name
                && level == LogLevel.Information)
            .AddConsole();
        }
        );
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseLoggerFactory(ConsoleLoggerFactory).EnableSensitiveDataLogging();
            optionsBuilder.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
            optionsBuilder.UseNpgsql(@"Host=localhost;Database=DepartmentalStoreData;Username=postgres;Password=root");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //Configuring Role
            modelBuilder.Entity<Role>().HasKey(r => r.Id);
            modelBuilder.Entity<Role>().HasMany(r => r.Staffs).WithOne(s => s.Role);
            modelBuilder.Entity<Role>().Property(r => r.Name).IsRequired().HasMaxLength(30);
            modelBuilder.Entity<Role>().HasIndex(r => r.Name).IsUnique();
            modelBuilder.Entity<Role>().Property(r => r.Description).IsRequired().HasMaxLength(100);

            //Configuring Address
            modelBuilder.Entity<Address>().HasKey(a => a.Id);
            modelBuilder.Entity<Address>().Property(a => a.AddressLine1).IsRequired().HasMaxLength(60);
            modelBuilder.Entity<Address>().Property(a => a.AddressLine2).HasMaxLength(60);
            modelBuilder.Entity<Address>().Property(a => a.City).IsRequired().HasMaxLength(30);
            modelBuilder.Entity<Address>().Property(a => a.State).IsRequired().HasMaxLength(30);
            modelBuilder.Entity<Address>().Property(a => a.Pincode).IsRequired().HasMaxLength(10);

            //Configuring Gender
            modelBuilder.Entity<Gender>().HasKey(g => g.Id);
            modelBuilder.Entity<Gender>().Property(g => g.Name).IsRequired().HasMaxLength(30);
            modelBuilder.Entity<Gender>().HasIndex(g => g.Name).IsUnique();

            //Configuring Staff
            modelBuilder.Entity<Staff>().HasKey(s => s.Id);
            modelBuilder.Entity<Staff>().HasOne(s => s.Role).WithMany(r => r.Staffs).HasForeignKey(s => s.RoleId).IsRequired();
            modelBuilder.Entity<Staff>().HasOne(s => s.Address).WithMany().HasForeignKey(s => s.AddressId).IsRequired();
            modelBuilder.Entity<Staff>().HasOne(s => s.Gender).WithMany().HasForeignKey(s => s.GenderId).IsRequired();
            modelBuilder.Entity<Staff>().Property(s => s.FirstName).IsRequired().HasMaxLength(30);
            modelBuilder.Entity<Staff>().Property(s => s.LastName).IsRequired().HasMaxLength(30);
            modelBuilder.Entity<Staff>().Property(s => s.PhoneNumber).IsRequired().HasMaxLength(10);
            modelBuilder.Entity<Staff>().HasIndex(s => s.PhoneNumber).IsUnique();
            modelBuilder.Entity<Staff>().Property(s => s.Email).IsRequired().HasMaxLength(30);
            modelBuilder.Entity<Staff>().HasIndex(s => s.Email).IsUnique();
            modelBuilder.Entity<Staff>().Property(s => s.Salary).IsRequired();

            //Configuring Product
            modelBuilder.Entity<Product>().HasKey(p => p.Id);
            modelBuilder.Entity<Product>().HasMany(p => p.ProductCategories).WithOne(pc => pc.Product);
            modelBuilder.Entity<Product>().HasMany(p => p.Prices).WithOne(pc => pc.Product);
            modelBuilder.Entity<Product>().HasOne(p => p.Inventory).WithOne(i => i.Product);
            modelBuilder.Entity<Product>().HasMany(p => p.ProductSuppliers).WithOne(ps => ps.Product);
            modelBuilder.Entity<Product>().Property(p => p.Name).IsRequired().HasMaxLength(30);
            modelBuilder.Entity<Product>().Property(p => p.ShortCode).IsRequired().HasMaxLength(4);
            modelBuilder.Entity<Product>().HasIndex(p => p.ShortCode).IsUnique();
            modelBuilder.Entity<Product>().Property(p => p.Manufacturer).IsRequired().HasMaxLength(30);
            modelBuilder.Entity<Product>().Property(p => p.Quantity).IsRequired();

            //Configuring Category
            modelBuilder.Entity<Category>().HasKey(c => c.Id);
            modelBuilder.Entity<Category>().HasMany(c => c.ProductCategories).WithOne(pc => pc.Category);
            modelBuilder.Entity<Category>().Property(c => c.Name).IsRequired().HasMaxLength(30);
            modelBuilder.Entity<Category>().Property(c => c.ShortCode).IsRequired().HasMaxLength(4);
            modelBuilder.Entity<Category>().HasIndex(c => c.ShortCode).IsUnique();

            //Configuring ProductCategory
            modelBuilder.Entity<ProductCategory>().HasKey(pc => new { pc.ProductId, pc.CategoryId });
            modelBuilder.Entity<ProductCategory>().HasOne(pc => pc.Product).WithMany(p => p.ProductCategories).HasForeignKey(pc => pc.ProductId);
            modelBuilder.Entity<ProductCategory>().HasOne(pc => pc.Category).WithMany(c => c.ProductCategories).HasForeignKey(pc => pc.CategoryId);

            //Configuring Price
            modelBuilder.Entity<Price>().HasKey(pc => pc.Id);
            modelBuilder.Entity<Price>().HasOne(pc => pc.Product).WithMany(p => p.Prices).HasForeignKey(pc => pc.ProductId);
            modelBuilder.Entity<Price>().Property(pc => pc.CostPrice).IsRequired();
            modelBuilder.Entity<Price>().Property(pc => pc.SellingPrice).IsRequired();
            modelBuilder.Entity<Price>().Property(pc => pc.EffectiveDate).IsRequired();

            //Configuring Inventory
            modelBuilder.Entity<Inventory>().HasKey(i => i.ProductId);
            modelBuilder.Entity<Inventory>().HasOne(i => i.Product).WithOne(p => p.Inventory).HasForeignKey<Inventory>(x => x.ProductId);

            //Configuring Supplier
            modelBuilder.Entity<Supplier>().HasKey(s => s.Id);
            modelBuilder.Entity<Supplier>().HasOne(s => s.Address).WithMany().HasForeignKey(s => s.AddressId).IsRequired();
            modelBuilder.Entity<Supplier>().HasMany(s => s.ProductSuppliers).WithOne(ps => ps.Supplier);
            modelBuilder.Entity<Supplier>().HasOne(s => s.Gender).WithMany().HasForeignKey(s => s.GenderId).IsRequired();
            modelBuilder.Entity<Supplier>().Property(s => s.FirstName).IsRequired();
            modelBuilder.Entity<Supplier>().Property(s => s.LastName).IsRequired();
            modelBuilder.Entity<Supplier>().Property(s => s.PhoneNumber).IsRequired().HasMaxLength(10);
            modelBuilder.Entity<Supplier>().HasIndex(s => s.PhoneNumber).IsUnique();
            modelBuilder.Entity<Supplier>().Property(s => s.Email).IsRequired();
            modelBuilder.Entity<Supplier>().HasIndex(s => s.Email).IsUnique();

            //Congfiguring ProductSupplier
            modelBuilder.Entity<ProductSupplier>().HasKey(ps => new { ps.ProductId, ps.SupplierId });
            modelBuilder.Entity<ProductSupplier>().HasOne(ps => ps.Product).WithMany(p => p.ProductSuppliers).HasForeignKey(ps => ps.ProductId);
            modelBuilder.Entity<ProductSupplier>().HasOne(ps => ps.Supplier).WithMany(s => s.ProductSuppliers).HasForeignKey(ps => ps.SupplierId);

            //Configuring Order
            modelBuilder.Entity<Order>().HasKey(o => o.Id);
            modelBuilder.Entity<Order>().HasOne(o => o.Supplier).WithMany().HasForeignKey(o => o.SupplierId);
            modelBuilder.Entity<Order>().HasMany(o => o.OrderDetails).WithOne(o => o.Order);
            modelBuilder.Entity<Order>().Property(o => o.OrderDate).IsRequired();

            //Configuring OrderDetail
            modelBuilder.Entity<OrderDetail>().HasKey(od => new { od.OrderId, od.ProductId });
            modelBuilder.Entity<OrderDetail>().HasOne(od => od.Order).WithMany(o => o.OrderDetails).HasForeignKey(od => od.OrderId);
            modelBuilder.Entity<OrderDetail>().HasOne(od => od.Product).WithMany().HasForeignKey(od => od.ProductId);
            modelBuilder.Entity<OrderDetail>().Property(od => od.Quantity).IsRequired();
        }
    }
}