﻿// <auto-generated />
using System;
using API.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace API.Data.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20230606164051_UserFKeysAdded")]
    partial class UserFKeysAdded
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("API.Entities.AppUser", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<byte[]>("PasswordHash")
                        .HasColumnType("bytea");

                    b.Property<byte[]>("PasswordSalt")
                        .HasColumnType("bytea");

                    b.Property<string>("UserName")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("API.Entities.Buyer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .HasColumnType("text");

                    b.Property<int?>("AppUserId")
                        .HasColumnType("integer");

                    b.Property<string>("BankAccount1")
                        .HasColumnType("text");

                    b.Property<string>("BankAccount2")
                        .HasColumnType("text");

                    b.Property<string>("BankAccount3")
                        .HasColumnType("text");

                    b.Property<string>("City")
                        .HasColumnType("text");

                    b.Property<string>("Country")
                        .HasColumnType("text");

                    b.Property<string>("IdentificationNumber")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("PostalCode")
                        .HasColumnType("text");

                    b.Property<string>("Swift")
                        .HasColumnType("text");

                    b.Property<string>("TaxNumber")
                        .HasColumnType("text");

                    b.Property<int>("Type")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("AppUserId");

                    b.ToTable("Buyers");
                });

            modelBuilder.Entity("API.Entities.InvoiceHeader", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("AppUserId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("ArrivalDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int?>("BuyerId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("DateOfIssuance")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<DateTime>("DocumentDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("FiscalNumber")
                        .HasColumnType("text");

                    b.Property<int>("InvoiceNumber")
                        .HasColumnType("integer");

                    b.Property<int>("NumberOfItems")
                        .HasColumnType("integer");

                    b.Property<string>("PlaceOfIssuance")
                        .HasColumnType("text");

                    b.Property<string>("Remark")
                        .HasColumnType("text");

                    b.Property<DateTime>("ShippingDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("Status")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("AppUserId");

                    b.HasIndex("BuyerId");

                    b.ToTable("InvoiceHeaders");
                });

            modelBuilder.Entity("API.Entities.InvoiceItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<decimal>("Discount")
                        .HasColumnType("numeric");

                    b.Property<int>("InvoiceHeaderId")
                        .HasColumnType("integer");

                    b.Property<decimal>("PriceOfService")
                        .HasColumnType("numeric");

                    b.Property<decimal>("PriceOfServiceInEuros")
                        .HasColumnType("numeric");

                    b.Property<int>("Quantity")
                        .HasColumnType("integer");

                    b.Property<decimal>("Tax")
                        .HasColumnType("numeric");

                    b.Property<decimal>("TotalPrice")
                        .HasColumnType("numeric");

                    b.HasKey("Id");

                    b.HasIndex("InvoiceHeaderId");

                    b.ToTable("InvoiceDetails");
                });

            modelBuilder.Entity("API.Entities.Service", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int?>("AppUserId")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<decimal>("Price")
                        .HasColumnType("numeric");

                    b.Property<decimal>("PriceInEuros")
                        .HasColumnType("numeric");

                    b.HasKey("Id");

                    b.HasIndex("AppUserId");

                    b.ToTable("Services");
                });

            modelBuilder.Entity("API.Entities.Buyer", b =>
                {
                    b.HasOne("API.Entities.AppUser", null)
                        .WithMany("Buyers")
                        .HasForeignKey("AppUserId");
                });

            modelBuilder.Entity("API.Entities.InvoiceHeader", b =>
                {
                    b.HasOne("API.Entities.AppUser", "AppUser")
                        .WithMany("InvoiceHeaders")
                        .HasForeignKey("AppUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("API.Entities.Buyer", "Buyer")
                        .WithMany()
                        .HasForeignKey("BuyerId");

                    b.Navigation("AppUser");

                    b.Navigation("Buyer");
                });

            modelBuilder.Entity("API.Entities.InvoiceItem", b =>
                {
                    b.HasOne("API.Entities.InvoiceHeader", "InvoiceHeader")
                        .WithMany("InvoiceItems")
                        .HasForeignKey("InvoiceHeaderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("InvoiceHeader");
                });

            modelBuilder.Entity("API.Entities.Service", b =>
                {
                    b.HasOne("API.Entities.AppUser", null)
                        .WithMany("Services")
                        .HasForeignKey("AppUserId");
                });

            modelBuilder.Entity("API.Entities.AppUser", b =>
                {
                    b.Navigation("Buyers");

                    b.Navigation("InvoiceHeaders");

                    b.Navigation("Services");
                });

            modelBuilder.Entity("API.Entities.InvoiceHeader", b =>
                {
                    b.Navigation("InvoiceItems");
                });
#pragma warning restore 612, 618
        }
    }
}
