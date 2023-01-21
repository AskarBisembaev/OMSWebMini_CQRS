﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using OMSWebMini.Data;

namespace OMSWebMini.Migrations
{
    [DbContext(typeof(NorthwindContext))]
    [Migration("20230113110008_Sales_By_Countries_Model")]
    partial class Sales_By_Countries_Model
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:Collation", "Cyrillic_General_CI_AS")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.9")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("OMSWebMini.Models.Category", b =>
                {
                    b.Property<int>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("CategoryID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.HasKey("CategoryId");

                    b.HasIndex(new[] { "CategoryName" }, "CategoryName");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("OMSWebMini.Models.Customer", b =>
                {
                    b.Property<string>("CustomerId")
                        .HasMaxLength(5)
                        .HasColumnType("nchar(5)")
                        .HasColumnName("CustomerID")
                        .IsFixedLength(true);

                    b.Property<string>("CompanyName")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.Property<string>("Country")
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.HasKey("CustomerId");

                    b.HasIndex(new[] { "CompanyName" }, "CompanyName");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("OMSWebMini.Models.Employee", b =>
                {
                    b.Property<int>("EmployeeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("EmployeeID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .HasMaxLength(60)
                        .HasColumnType("nvarchar(60)");

                    b.Property<DateTime?>("BirthDate")
                        .HasColumnType("datetime");

                    b.Property<string>("City")
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.Property<string>("Country")
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.Property<string>("Extension")
                        .HasMaxLength(4)
                        .HasColumnType("nvarchar(4)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<DateTime?>("HireDate")
                        .HasColumnType("datetime");

                    b.Property<string>("HomePhone")
                        .HasMaxLength(24)
                        .HasColumnType("nvarchar(24)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("Notes")
                        .HasColumnType("ntext");

                    b.Property<byte[]>("Photo")
                        .HasColumnType("image");

                    b.Property<string>("PhotoPath")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("PostalCode")
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("Region")
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.Property<int?>("ReportsTo")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("TitleOfCourtesy")
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.HasKey("EmployeeId");

                    b.HasIndex("ReportsTo");

                    b.HasIndex(new[] { "LastName" }, "LastName");

                    b.HasIndex(new[] { "PostalCode" }, "PostalCode");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("OMSWebMini.Models.Order", b =>
                {
                    b.Property<int>("OrderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("OrderID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CustomerId")
                        .HasMaxLength(5)
                        .HasColumnType("nchar(5)")
                        .HasColumnName("CustomerID")
                        .IsFixedLength(true);

                    b.Property<int?>("EmployeeId")
                        .HasColumnType("int");

                    b.Property<string>("ShipCountry")
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.HasKey("OrderId");

                    b.HasIndex("EmployeeId");

                    b.HasIndex(new[] { "CustomerId" }, "CustomerID");

                    b.HasIndex(new[] { "CustomerId" }, "CustomersOrders");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("OMSWebMini.Models.OrderDetail", b =>
                {
                    b.Property<int>("OrderId")
                        .HasColumnType("int")
                        .HasColumnName("OrderID");

                    b.Property<int>("ProductId")
                        .HasColumnType("int")
                        .HasColumnName("ProductID");

                    b.Property<short>("Quantity")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("smallint")
                        .HasDefaultValueSql("((1))");

                    b.Property<decimal>("UnitPrice")
                        .HasColumnType("money");

                    b.HasKey("OrderId", "ProductId")
                        .HasName("PK_Order_Details");

                    b.HasIndex(new[] { "OrderId" }, "OrderID");

                    b.HasIndex(new[] { "OrderId" }, "OrdersOrder_Details");

                    b.HasIndex(new[] { "ProductId" }, "ProductID");

                    b.HasIndex(new[] { "ProductId" }, "ProductsOrder_Details");

                    b.ToTable("Order Details");
                });

            modelBuilder.Entity("OMSWebMini.Models.OrdersByCountry", b =>
                {
                    b.Property<string>("CountryName")
                        .HasMaxLength(100)
                        .HasColumnType("nchar(100)")
                        .IsFixedLength(true);

                    b.Property<int>("OrdersCount")
                        .HasColumnType("int");

                    b.HasKey("CountryName");

                    b.ToTable("OrdersByCountries");
                });

            modelBuilder.Entity("OMSWebMini.Models.Product", b =>
                {
                    b.Property<int>("ProductId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ProductID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CategoryId")
                        .HasColumnType("int")
                        .HasColumnName("CategoryID");

                    b.HasKey("ProductId");

                    b.HasIndex(new[] { "CategoryId" }, "CategoriesProducts");

                    b.HasIndex(new[] { "CategoryId" }, "CategoryID");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("OMSWebMini.Models.SalesByCategories", b =>
                {
                    b.Property<string>("CategoryName")
                        .HasMaxLength(100)
                        .HasColumnType("nchar(100)")
                        .IsFixedLength(true);

                    b.Property<int>("Sales")
                        .HasColumnType("int");

                    b.HasKey("CategoryName");

                    b.ToTable("SalesByCategories");
                });

            modelBuilder.Entity("OMSWebMini.Models.Employee", b =>
                {
                    b.HasOne("OMSWebMini.Models.Employee", "ReportsToNavigation")
                        .WithMany("InverseReportsToNavigation")
                        .HasForeignKey("ReportsTo")
                        .HasConstraintName("FK_Employees_Employees");

                    b.Navigation("ReportsToNavigation");
                });

            modelBuilder.Entity("OMSWebMini.Models.Order", b =>
                {
                    b.HasOne("OMSWebMini.Models.Customer", "Customer")
                        .WithMany("Orders")
                        .HasForeignKey("CustomerId")
                        .HasConstraintName("FK_Orders_Customers");

                    b.HasOne("OMSWebMini.Models.Employee", null)
                        .WithMany("Orders")
                        .HasForeignKey("EmployeeId");

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("OMSWebMini.Models.OrderDetail", b =>
                {
                    b.HasOne("OMSWebMini.Models.Order", "Order")
                        .WithMany("OrderDetails")
                        .HasForeignKey("OrderId")
                        .HasConstraintName("FK_Order_Details_Orders")
                        .IsRequired();

                    b.HasOne("OMSWebMini.Models.Product", "Product")
                        .WithMany("OrderDetails")
                        .HasForeignKey("ProductId")
                        .HasConstraintName("FK_Order_Details_Products")
                        .IsRequired();

                    b.Navigation("Order");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("OMSWebMini.Models.Product", b =>
                {
                    b.HasOne("OMSWebMini.Models.Category", "Category")
                        .WithMany("Products")
                        .HasForeignKey("CategoryId")
                        .HasConstraintName("FK_Products_Categories");

                    b.Navigation("Category");
                });

            modelBuilder.Entity("OMSWebMini.Models.Category", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("OMSWebMini.Models.Customer", b =>
                {
                    b.Navigation("Orders");
                });

            modelBuilder.Entity("OMSWebMini.Models.Employee", b =>
                {
                    b.Navigation("InverseReportsToNavigation");

                    b.Navigation("Orders");
                });

            modelBuilder.Entity("OMSWebMini.Models.Order", b =>
                {
                    b.Navigation("OrderDetails");
                });

            modelBuilder.Entity("OMSWebMini.Models.Product", b =>
                {
                    b.Navigation("OrderDetails");
                });
#pragma warning restore 612, 618
        }
    }
}
