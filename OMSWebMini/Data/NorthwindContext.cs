﻿using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using OMSWebMini.Models;

#nullable disable

namespace OMSWebMini.Data
{
    public partial class NorthwindContext : DbContext
    {
        public NorthwindContext()
        {
        }

        public NorthwindContext(DbContextOptions<NorthwindContext> options)
            : base(options)
        {
        }
		public virtual DbSet<Summary> Summary { get; set; }
		public virtual DbSet<OrdersByCountry> OrdersByCountries { get; set; }
        public DbSet<SalesByCategories> SalesByCategories { get; set; }
		public virtual DbSet<CustomersByCountries> CustomersByCountries { get; set; }
		public virtual DbSet<ProductsByCategories> ProductsByCategories { get; set; }
		public virtual DbSet<PurchasesByCustomers> PurchasesByCustomers { get; set; }
		public virtual DbSet<SalesByEmployees> SalesByEmployees { get; set; }
		public virtual DbSet<SalesByCountries> SalesByCountries{get; set;}
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<OrderDetail> OrderDetails { get; set; }
        public virtual DbSet<Product> Products { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=.\\SQLEXPRESS;Database=Northwind;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Cyrillic_General_CI_AS");

			modelBuilder.Entity<Summary>(entity =>
			{
				entity.Property(e => e.id)
					.ValueGeneratedNever()
					.HasColumnName("id");

				entity.Property(e => e.Average).HasColumnType("int");

				entity.Property(e => e.MaxCheck).HasColumnType("int");

				entity.Property(e => e.MinChek).HasColumnType("int");

				entity.Property(e => e.OverallSalesSum).HasColumnType("int");
			});

			modelBuilder.Entity<SalesByEmployees>(entity =>
			{
				entity.HasKey(e => e.EmployeeName);

				entity.Property(e => e.EmployeeName)
					.HasMaxLength(100)
					.IsFixedLength(true);
			});

			modelBuilder.Entity<PurchasesByCustomers>(entity =>
			{
				entity.HasKey(e => e.CompanyName);

				entity.Property(e => e.CompanyName)
					.HasMaxLength(100)
					.IsFixedLength(true);
			});

			modelBuilder.Entity<ProductsByCategories>(entity =>
			{
				entity.HasKey(e => e.CategoryName);

				entity.Property(e => e.CategoryName)
					.HasMaxLength(100)
					.IsFixedLength(true);
			});

			modelBuilder.Entity<CustomersByCountries>(entity =>
			{
				entity.HasKey(e => e.CountryName);

				entity.Property(e => e.CountryName)
					.HasMaxLength(100)
					.IsFixedLength(true);
			});

			modelBuilder.Entity<SalesByCountries>(entity =>
			{
				entity.HasKey(e => e.CountryName);

			entity.Property(e => e.CountryName)
				.HasMaxLength(100)
				.IsFixedLength(true);
			});

			modelBuilder.Entity<SalesByCategories>(entity =>
            {
                entity.HasKey(e => e.CategoryName);

                entity.Property(e => e.CategoryName)
                    .HasMaxLength(100)
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<OrdersByCountry>(entity =>
            {
                entity.HasKey(e => e.CountryName);

                entity.Property(e => e.CountryName)
                    .HasMaxLength(100)
                    .IsFixedLength(true);
            });


            modelBuilder.Entity<Category>(entity =>
            {
                entity.HasIndex(e => e.CategoryName, "CategoryName");

                entity.Property(e => e.CategoryId).HasColumnName("CategoryID");

                entity.Property(e => e.CategoryName)
                    .IsRequired()
                    .HasMaxLength(15);

                //entity.Property(e => e.Description).HasColumnType("ntext");

                //entity.Property(e => e.Picture).HasColumnType("image");
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                //entity.HasIndex(e => e.City, "City");

                entity.HasIndex(e => e.CompanyName, "CompanyName");

                //entity.HasIndex(e => e.PostalCode, "PostalCode");

                //entity.HasIndex(e => e.Region, "Region");

                entity.Property(e => e.CustomerId)
                    .HasMaxLength(5)
                    .HasColumnName("CustomerID")
                    .IsFixedLength(true);

                //entity.Property(e => e.Address).HasMaxLength(60);

                //entity.Property(e => e.City).HasMaxLength(15);

                entity.Property(e => e.CompanyName)
                    .IsRequired()
                    .HasMaxLength(40);

                //entity.Property(e => e.ContactName).HasMaxLength(30);

                //entity.Property(e => e.ContactTitle).HasMaxLength(30);

                entity.Property(e => e.Country).HasMaxLength(15);

                //entity.Property(e => e.Fax).HasMaxLength(24);

                //entity.Property(e => e.Phone).HasMaxLength(24);

                //entity.Property(e => e.PostalCode).HasMaxLength(10);

                //entity.Property(e => e.Region).HasMaxLength(15);
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.HasIndex(e => e.LastName, "LastName");

                entity.HasIndex(e => e.PostalCode, "PostalCode");

                entity.Property(e => e.EmployeeId).HasColumnName("EmployeeID");

                entity.Property(e => e.Address).HasMaxLength(60);

                entity.Property(e => e.BirthDate).HasColumnType("datetime");

                entity.Property(e => e.City).HasMaxLength(15);

                entity.Property(e => e.Country).HasMaxLength(15);

                entity.Property(e => e.Extension).HasMaxLength(4);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.Property(e => e.HireDate).HasColumnType("datetime");

                entity.Property(e => e.HomePhone).HasMaxLength(24);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.Notes).HasColumnType("ntext");

                entity.Property(e => e.Photo).HasColumnType("image");

                entity.Property(e => e.PhotoPath).HasMaxLength(255);

                entity.Property(e => e.PostalCode).HasMaxLength(10);

                entity.Property(e => e.Region).HasMaxLength(15);

                entity.Property(e => e.Title).HasMaxLength(30);

                entity.Property(e => e.TitleOfCourtesy).HasMaxLength(25);

                entity.HasOne(d => d.ReportsToNavigation)
                    .WithMany(p => p.InverseReportsToNavigation)
                    .HasForeignKey(d => d.ReportsTo)
                    .HasConstraintName("FK_Employees_Employees");
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.HasIndex(e => e.CustomerId, "CustomerID");

                entity.HasIndex(e => e.CustomerId, "CustomersOrders");

                entity.HasIndex(e => e.EmployeeId, "EmployeeID");

                entity.HasIndex(e => e.EmployeeId, "EmployeesOrders");

                //entity.HasIndex(e => e.OrderDate, "OrderDate");

                //entity.HasIndex(e => e.ShipPostalCode, "ShipPostalCode");

                //entity.HasIndex(e => e.ShippedDate, "ShippedDate");

                //entity.HasIndex(e => e.ShipVia, "ShippersOrders");

                entity.Property(e => e.OrderId).HasColumnName("OrderID");

                entity.Property(e => e.CustomerId)
                    .HasMaxLength(5)
                    .HasColumnName("CustomerID")
                    .IsFixedLength(true);

                entity.Property(e => e.EmployeeId).HasColumnName("EmployeeID");

                //entity.Property(e => e.Freight)
                //    .HasColumnType("money")
                //    .HasDefaultValueSql("((0))");

                //entity.Property(e => e.OrderDate).HasColumnType("datetime");

                //entity.Property(e => e.RequiredDate).HasColumnType("datetime");

                //entity.Property(e => e.ShipAddress).HasMaxLength(60);

                //entity.Property(e => e.ShipCity).HasMaxLength(15);

                entity.Property(e => e.ShipCountry).HasMaxLength(15);

                //entity.Property(e => e.ShipName).HasMaxLength(40);

                //entity.Property(e => e.ShipPostalCode).HasMaxLength(10);

                //entity.Property(e => e.ShipRegion).HasMaxLength(15);

                //entity.Property(e => e.ShippedDate).HasColumnType("datetime");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.CustomerId)
                    .HasConstraintName("FK_Orders_Customers");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.EmployeeId)
                    .HasConstraintName("FK_Orders_Employees");

            });

            modelBuilder.Entity<OrderDetail>(entity =>
            {
                entity.HasKey(e => new { e.OrderId, e.ProductId })
                    .HasName("PK_Order_Details");

                entity.ToTable("Order Details");

                entity.HasIndex(e => e.OrderId, "OrderID");

                entity.HasIndex(e => e.OrderId, "OrdersOrder_Details");

                entity.HasIndex(e => e.ProductId, "ProductID");

                entity.HasIndex(e => e.ProductId, "ProductsOrder_Details");

                entity.Property(e => e.OrderId).HasColumnName("OrderID");

                entity.Property(e => e.ProductId).HasColumnName("ProductID");

                entity.Property(e => e.Quantity).HasDefaultValueSql("((1))");

                entity.Property(e => e.UnitPrice).HasColumnType("money");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.OrderDetails)
                    .HasForeignKey(d => d.OrderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Order_Details_Orders");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.OrderDetails)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Order_Details_Products");
            });



            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasIndex(e => e.CategoryId, "CategoriesProducts");

                entity.HasIndex(e => e.CategoryId, "CategoryID");

                entity.HasIndex(e => e.ProductName, "ProductName");

                //entity.HasIndex(e => e.SupplierId, "SupplierID");

                //entity.HasIndex(e => e.SupplierId, "SuppliersProducts");

                entity.Property(e => e.ProductId).HasColumnName("ProductID");

                entity.Property(e => e.CategoryId).HasColumnName("CategoryID");

                //entity.Property(e => e.ProductName)
                //    .IsRequired()
                //    .HasMaxLength(40);

                //entity.Property(e => e.QuantityPerUnit).HasMaxLength(20);

                //entity.Property(e => e.ReorderLevel).HasDefaultValueSql("((0))");

                //entity.Property(e => e.SupplierId).HasColumnName("SupplierID");

                //entity.Property(e => e.UnitPrice)
                //    .HasColumnType("money")
                //    .HasDefaultValueSql("((0))");

                //entity.Property(e => e.UnitsInStock).HasDefaultValueSql("((0))");

                //entity.Property(e => e.UnitsOnOrder).HasDefaultValueSql("((0))");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.CategoryId)
                    .HasConstraintName("FK_Products_Categories");


            });


            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
