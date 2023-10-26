﻿// <auto-generated />
using System;
using BankData;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BankData.Migrations
{
    [DbContext(typeof(BankDbContext))]
    partial class BankDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("BankData.Model.CDT", b =>
                {
                    b.Property<int>("IdCDT")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdCDT"));

                    b.Property<long>("Balance")
                        .HasColumnType("bigint");

                    b.Property<decimal>("InterestRate")
                        .HasColumnType("decimal(12, 2)");

                    b.Property<bool>("State")
                        .HasColumnType("bit");

                    b.HasKey("IdCDT");

                    b.ToTable("CDT");
                });

            modelBuilder.Entity("BankData.Model.Client", b =>
                {
                    b.Property<int>("IdClient")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdClient"));

                    b.Property<int?>("IdCDT")
                        .HasColumnType("int");

                    b.Property<int?>("IdCurrentAccount")
                        .HasColumnType("int");

                    b.Property<int?>("IdLegalRepresentative")
                        .HasColumnType("int");

                    b.Property<int?>("IdSavingsAccount")
                        .HasColumnType("int");

                    b.Property<string>("IdentificationNumber")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("varchar(20)");

                    b.Property<int>("IdentificationType")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.HasKey("IdClient");

                    b.HasIndex("IdCDT");

                    b.HasIndex("IdCurrentAccount");

                    b.HasIndex("IdLegalRepresentative");

                    b.HasIndex("IdSavingsAccount");

                    b.ToTable("Client");
                });

            modelBuilder.Entity("BankData.Model.Country", b =>
                {
                    b.Property<int>("IdCountry")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdCountry"));

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasMaxLength(3)
                        .HasColumnType("varchar(3)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.HasKey("IdCountry");

                    b.ToTable("Country");
                });

            modelBuilder.Entity("BankData.Model.CurrentAccount", b =>
                {
                    b.Property<int>("IdCurrentAccount")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdCurrentAccount"));

                    b.Property<long>("Balance")
                        .HasColumnType("bigint");

                    b.Property<bool>("State")
                        .HasColumnType("bit");

                    b.HasKey("IdCurrentAccount");

                    b.ToTable("CurrentAccount");
                });

            modelBuilder.Entity("BankData.Model.LegalRepresentative", b =>
                {
                    b.Property<int>("IdLegalRepresentative")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdLegalRepresentative"));

                    b.Property<int>("IdCountry")
                        .HasColumnType("int");

                    b.Property<string>("IdentificationNumber")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("varchar(20)");

                    b.Property<int>("IdentificationType")
                        .HasColumnType("int");

                    b.Property<string>("MobileNumber")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("varchar(20)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(100)");

                    b.HasKey("IdLegalRepresentative");

                    b.HasIndex("IdCountry");

                    b.ToTable("LegalRepresentative");
                });

            modelBuilder.Entity("BankData.Model.SavingsAccount", b =>
                {
                    b.Property<int>("IdSavingsAccount")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdSavingsAccount"));

                    b.Property<long>("Balance")
                        .HasColumnType("bigint");

                    b.Property<decimal>("InterestRate")
                        .HasColumnType("decimal(12, 2)");

                    b.Property<bool>("State")
                        .HasColumnType("bit");

                    b.HasKey("IdSavingsAccount");

                    b.ToTable("SavingsAccount");
                });

            modelBuilder.Entity("BankData.Model.Client", b =>
                {
                    b.HasOne("BankData.Model.CDT", "CDT")
                        .WithMany()
                        .HasForeignKey("IdCDT");

                    b.HasOne("BankData.Model.CurrentAccount", "CurrentAccount")
                        .WithMany()
                        .HasForeignKey("IdCurrentAccount");

                    b.HasOne("BankData.Model.LegalRepresentative", "LegalRepresentative")
                        .WithMany()
                        .HasForeignKey("IdLegalRepresentative");

                    b.HasOne("BankData.Model.SavingsAccount", "SavingsAccount")
                        .WithMany()
                        .HasForeignKey("IdSavingsAccount");

                    b.Navigation("CDT");

                    b.Navigation("CurrentAccount");

                    b.Navigation("LegalRepresentative");

                    b.Navigation("SavingsAccount");
                });

            modelBuilder.Entity("BankData.Model.LegalRepresentative", b =>
                {
                    b.HasOne("BankData.Model.Country", "Country")
                        .WithMany()
                        .HasForeignKey("IdCountry")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Country");
                });
#pragma warning restore 612, 618
        }
    }
}
