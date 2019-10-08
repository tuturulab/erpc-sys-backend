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
    [Migration("20191008234814_ventas")]
    partial class ventas
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

                    b.Property<int>("AccountId");

                    b.Property<string>("Description");

                    b.Property<string>("Logo");

                    b.Property<string>("Name");

                    b.HasKey("CompanyId");

                    b.HasIndex("AccountId")
                        .IsUnique();

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

                    b.Property<string>("Description");

                    b.Property<string>("DocumentNumber");

                    b.Property<string>("Email");

                    b.Property<string>("Name");

                    b.Property<string>("Picture");

                    b.HasKey("EmployeeId");

                    b.HasIndex("AccountId");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("erpc_system_backend.Models.EmployeeAdministration", b =>
                {
                    b.Property<int>("EmployeeAdministrationId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("EmployeeId");

                    b.Property<int>("IsActive");

                    b.Property<double>("Salary");

                    b.HasKey("EmployeeAdministrationId");

                    b.HasIndex("EmployeeId")
                        .IsUnique();

                    b.ToTable("EmployeeAdministrations");
                });

            modelBuilder.Entity("erpc_system_backend.Models.Event", b =>
                {
                    b.Property<int>("EventId")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("CompanyAccountId");

                    b.Property<string>("description");

                    b.Property<DateTime>("end");

                    b.Property<DateTime>("start");

                    b.Property<string>("title");

                    b.HasKey("EventId");

                    b.HasIndex("CompanyAccountId");

                    b.ToTable("Events");
                });

            modelBuilder.Entity("erpc_system_backend.Models.Interview", b =>
                {
                    b.Property<int>("InterviewId")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("AccountId");

                    b.Property<string>("Cellphone");

                    b.Property<string>("Curriculum");

                    b.Property<string>("DocumentNumber");

                    b.Property<string>("Email");

                    b.Property<string>("FullName");

                    b.Property<bool>("Result");

                    b.Property<DateTime>("ToInterview");

                    b.HasKey("InterviewId");

                    b.HasIndex("AccountId");

                    b.ToTable("Interviews");
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

                    b.Property<string>("Description");

                    b.Property<bool>("Ecommerce");

                    b.Property<int>("MinStock");

                    b.Property<string>("Name");

                    b.Property<string>("Picture");

                    b.Property<double>("Price");

                    b.Property<int>("Stock");

                    b.HasKey("ProductId");

                    b.HasIndex("AccountId");

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

                    b.ToTable("Sales");
                });

            modelBuilder.Entity("erpc_system_backend.Models.SpecsProduct", b =>
                {
                    b.Property<int>("SpecsProductId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<DateTime>("Garantia");

                    b.Property<string>("IMEI");

                    b.Property<int?>("ProductId");

                    b.Property<int?>("SaleId");

                    b.HasKey("SpecsProductId");

                    b.HasIndex("ProductId");

                    b.HasIndex("SaleId");

                    b.ToTable("SpecsProduct");
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

            modelBuilder.Entity("erpc_system_backend.Models.Vacation", b =>
                {
                    b.Property<int>("VacationId")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("EmployeeId");

                    b.Property<DateTime>("End");

                    b.Property<string>("Observation");

                    b.Property<DateTime>("Start");

                    b.HasKey("VacationId");

                    b.HasIndex("EmployeeId");

                    b.ToTable("Vacations");
                });

            modelBuilder.Entity("erpc_system_backend.Models.Account", b =>
                {
                    b.HasOne("erpc_system_backend.Models.Plan", "Plan")
                        .WithMany("Accounts")
                        .HasForeignKey("PlanId");
                });

            modelBuilder.Entity("erpc_system_backend.Models.Company", b =>
                {
                    b.HasOne("erpc_system_backend.Models.Account", "Account")
                        .WithOne("Company")
                        .HasForeignKey("erpc_system_backend.Models.Company", "AccountId")
                        .OnDelete(DeleteBehavior.Cascade);
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

            modelBuilder.Entity("erpc_system_backend.Models.EmployeeAdministration", b =>
                {
                    b.HasOne("erpc_system_backend.Models.Employee", "Employee")
                        .WithOne("EmployeeAdministration")
                        .HasForeignKey("erpc_system_backend.Models.EmployeeAdministration", "EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("erpc_system_backend.Models.Event", b =>
                {
                    b.HasOne("erpc_system_backend.Models.Account", "Company")
                        .WithMany("Events")
                        .HasForeignKey("CompanyAccountId");
                });

            modelBuilder.Entity("erpc_system_backend.Models.Interview", b =>
                {
                    b.HasOne("erpc_system_backend.Models.Account", "Account")
                        .WithMany("Interviews")
                        .HasForeignKey("AccountId");
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

            modelBuilder.Entity("erpc_system_backend.Models.SpecsProduct", b =>
                {
                    b.HasOne("erpc_system_backend.Models.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId");

                    b.HasOne("erpc_system_backend.Models.Sale", "Sale")
                        .WithMany()
                        .HasForeignKey("SaleId");
                });

            modelBuilder.Entity("erpc_system_backend.Models.Vacation", b =>
                {
                    b.HasOne("erpc_system_backend.Models.Employee", "Employee")
                        .WithMany("Vacations")
                        .HasForeignKey("EmployeeId");
                });
#pragma warning restore 612, 618
        }
    }
}
