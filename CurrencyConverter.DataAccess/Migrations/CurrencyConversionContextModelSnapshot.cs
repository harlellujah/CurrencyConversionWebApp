﻿// <auto-generated />
using System;
using CurrencyConverter.DataAccess.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CurrencyConverter.DataAccess.Migrations
{
    [DbContext(typeof(CurrencyConversionContext))]
    partial class CurrencyConversionContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.11")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CurrencyConverter.Business.Entities.Conversion.ConversionEntity", b =>
                {
                    b.Property<Guid>("ConversionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("BaseSymbol")
                        .HasColumnType("int");

                    b.Property<double>("BaseValue")
                        .HasColumnType("float");

                    b.Property<double>("ConvertedValue")
                        .HasColumnType("float");

                    b.Property<double>("ExchangeRate")
                        .HasColumnType("float");

                    b.Property<Guid>("SessionId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("TargetSymbol")
                        .HasColumnType("int");

                    b.HasKey("ConversionId");

                    b.HasIndex("ConversionId")
                        .IsUnique();

                    b.ToTable("Conversion");
                });
#pragma warning restore 612, 618
        }
    }
}
