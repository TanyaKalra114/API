﻿// <auto-generated />
using System;
using InsuranceAPI.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace InsuranceAPI.Migrations
{
    [DbContext(typeof(CustomerDbContext))]
    [Migration("20220325101244_removed fk")]
    partial class removedfk
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("InsuranceAPI.Models.Car", b =>
                {
                    b.Property<Guid>("policy_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("end_date")
                        .HasColumnType("datetime2");

                    b.Property<string>("model_no")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("policy_type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("start_date")
                        .HasColumnType("datetime2");

                    b.HasKey("policy_id");

                    b.ToTable("Cars");
                });

            modelBuilder.Entity("InsuranceAPI.Models.Customer", b =>
                {
                    b.Property<Guid>("customer_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("customer_name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("date_of_birth")
                        .HasColumnType("datetime2");

                    b.Property<string>("email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("gender")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("phone_no")
                        .HasColumnType("int");

                    b.HasKey("customer_id");

                    b.ToTable("Customers");
                });
#pragma warning restore 612, 618
        }
    }
}
