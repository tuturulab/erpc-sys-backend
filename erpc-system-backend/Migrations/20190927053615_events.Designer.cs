﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using erpc_system_backend.Models;

namespace erpc_system_backend.Migrations
{
    [DbContext(typeof(ErpcDbContext))]
    [Migration("20190927053615_events")]
    partial class events
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("erpc_system_backend.Models.Account", b =>
                {
                    b.Property<int>("AccountId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Features");

                    b.Property<int?>("PlanId");

                    b.Property<int>("SubscriptionId");

                    b.HasKey("AccountId");

                    b.HasIndex("PlanId");

                    b.ToTable("Accounts");
                });

            modelBuilder.Entity("erpc_system_backend.Models.Company", b =>
                {
                    b.Property<int>("CompanyId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<string>("Logo");

                    b.Property<string>("Name");

                    b.HasKey("CompanyId");

                    b.ToTable("Companies");
                });

            modelBuilder.Entity("erpc_system_backend.Models.Customer", b =>
                {
                    b.Property<int>("CustomerId")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("AccountId");

                    b.Property<string>("Cellphone");

                    b.Property<string>("Document");

                    b.Property<string>("Email");

                    b.Property<string>("Name");

                    b.HasKey("CustomerId");

                    b.HasIndex("AccountId");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("erpc_system_backend.Models.Deparment", b =>
                {
                    b.Property<int>("DeparmentId")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("AccountId");

                    b.Property<string>("Description");

                    b.Property<string>("Name");

                    b.HasKey("DeparmentId");

                    b.HasIndex("AccountId");

                    b.ToTable("Deparment");
                });

            modelBuilder.Entity("erpc_system_backend.Models.Employee", b =>
                {
                    b.Property<int>("EmployeeId")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("AccountId");

                    b.Property<string>("Cellphone");

                    b.Property<string>("Document");

                    b.Property<string>("Name");

                    b.HasKey("EmployeeId");

                    b.HasIndex("AccountId");

                    b.ToTable("Employee");
                });

            modelBuilder.Entity("erpc_system_backend.Models.Event", b =>
                {
                    b.Property<int>("EventId")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("CompanyAccountId");

                    b.Property<DateTime>("end");

                    b.Property<DateTime>("start");

                    b.Property<string>("title");

                    b.HasKey("EventId");

                    b.HasIndex("CompanyAccountId");

                    b.ToTable("Events");
                });

            modelBuilder.Entity("erpc_system_backend.Models.Membership", b =>
                {
                    b.Property<int>("AccountId");

                    b.Property<int>("UserId");

                    b.Property<string>("Access");

                    b.Property<int>("MembershipId");

                    b.HasKey("AccountId", "UserId");

                    b.HasIndex("UserId");

                    b.ToTable("Memberships");
                });

            modelBuilder.Entity("erpc_system_backend.Models.Payment", b =>
                {
                    b.Property<int>("PaymentId")
                        .ValueGeneratedOnAdd();

                    b.Property<double>("Amount");

                    b.Property<DateTime>("Date");

                    b.Property<int?>("SaleId");

                    b.HasKey("PaymentId");

                    b.HasIndex("SaleId");

                    b.ToTable("Payment");
                });

            modelBuilder.Entity("erpc_system_backend.Models.Plan", b =>
                {
                    b.Property<int>("PlanId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Feautures");

                    b.Property<string>("Name");

                    b.HasKey("PlanId");

                    b.ToTable("Plans");
                });

            modelBuilder.Entity("erpc_system_backend.Models.Product", b =>
                {
                    b.Property<int>("ProductId")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("AccountId");

                    b.Property<int?>("CompanyId");

                    b.Property<string>("Description");

                    b.Property<bool>("Ecommerce");

                    b.Property<int>("MinStock");

                    b.Property<string>("Name");

                    b.Property<string>("Picture");

                    b.Property<double>("Price");

                    b.Property<int>("Stock");

                    b.HasKey("ProductId");

                    b.HasIndex("AccountId");

                    b.HasIndex("CompanyId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("erpc_system_backend.Models.Sale", b =>
                {
                    b.Property<int>("SaleId")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("AccountId");

                    b.Property<string>("Code");

                    b.Property<int?>("CustomerId");

                    b.Property<DateTime>("Date");

                    b.Property<string>("Type");

                    b.HasKey("SaleId");

                    b.HasIndex("AccountId");

                    b.HasIndex("CustomerId");

                    b.ToTable("Sale");
                });

            modelBuilder.Entity("erpc_system_backend.Models.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Email");

                    b.Property<string>("HashedPassword");

                    b.Property<string>("Name");

                    b.Property<string>("Token");

                    b.HasKey("UserId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("erpc_system_backend.Models.Account", b =>
                {
                    b.HasOne("erpc_system_backend.Models.Plan", "Plan")
                        .WithMany("Accounts")
                        .HasForeignKey("PlanId");
                });

            modelBuilder.Entity("erpc_system_backend.Models.Customer", b =>
                {
                    b.HasOne("erpc_system_backend.Models.Account", "Account")
                        .WithMany("Customers")
                        .HasForeignKey("AccountId");
                });

            modelBuilder.Entity("erpc_system_backend.Models.Deparment", b =>
                {
                    b.HasOne("erpc_system_backend.Models.Account", "Account")
                        .WithMany("Deparments")
                        .HasForeignKey("AccountId");
                });

            modelBuilder.Entity("erpc_system_backend.Models.Employee", b =>
                {
                    b.HasOne("erpc_system_backend.Models.Account", "Account")
                        .WithMany("Employees")
                        .HasForeignKey("AccountId");
                });

            modelBuilder.Entity("erpc_system_backend.Models.Event", b =>
                {
                    b.HasOne("erpc_system_backend.Models.Account", "Company")
                        .WithMany("Events")
                        .HasForeignKey("CompanyAccountId");
                });

            modelBuilder.Entity("erpc_system_backend.Models.Membership", b =>
                {
                    b.HasOne("erpc_system_backend.Models.Account", "Account")
                        .WithMany("Memberships")
                        .HasForeignKey("AccountId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("erpc_system_backend.Models.User", "User")
                        .WithMany("Memberships")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("erpc_system_backend.Models.Payment", b =>
                {
                    b.HasOne("erpc_system_backend.Models.Sale", "Sale")
                        .WithMany("Payments")
                        .HasForeignKey("SaleId");
                });

            modelBuilder.Entity("erpc_system_backend.Models.Product", b =>
                {
                    b.HasOne("erpc_system_backend.Models.Account", "Account")
                        .WithMany("Products")
                        .HasForeignKey("AccountId");

                    b.HasOne("erpc_system_backend.Models.Company", "Company")
                        .WithMany("Products")
                        .HasForeignKey("CompanyId");
                });

            modelBuilder.Entity("erpc_system_backend.Models.Sale", b =>
                {
                    b.HasOne("erpc_system_backend.Models.Account", "Account")
                        .WithMany("Sales")
                        .HasForeignKey("AccountId");

                    b.HasOne("erpc_system_backend.Models.Customer", "Customer")
                        .WithMany("Sales")
                        .HasForeignKey("CustomerId");
                });
#pragma warning restore 612, 618
        }
    }
}
