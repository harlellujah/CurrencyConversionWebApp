using CurrencyConverter.Business.Entities.Conversion;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyConverter.DataAccess.Context
{
    public class CurrencyConversionContext : DbContext
    {
        public CurrencyConversionContext(DbContextOptions<CurrencyConversionContext> options) : base(options)
        {

        }

        public DbSet<ConversionEntity> Conversions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ConversionEntity>(entity =>
            {
                entity.HasKey(e => e.ConversionId);
                entity.HasIndex(e => e.ConversionId).IsUnique();
            });

            modelBuilder.Entity<ConversionEntity>().ToTable("Conversion");
        }
    }
}
