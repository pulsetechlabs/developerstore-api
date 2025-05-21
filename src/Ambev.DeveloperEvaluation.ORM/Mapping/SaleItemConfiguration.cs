using Ambev.DeveloperEvaluation.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.ORM.Mapping
{
    public class SaleItemConfiguration : IEntityTypeConfiguration<SaleItem>
    {
        public void Configure(EntityTypeBuilder<SaleItem> builder)
        {
            builder.ToTable("SaleItems");

            builder.HasKey(s => s.Id);
            builder.Property(s => s.Id).HasColumnName("uuid").HasDefaultValueSql("gen_random_uuid()");

            builder.Property(s => s.SaleId).IsRequired();
            builder.Property(s => s.ProductId).IsRequired();
            builder.Property(s => s.ProductName).IsRequired().HasMaxLength(100);
            builder.Property(s => s.Quantity).IsRequired();
            builder.Property(s => s.UnitPrice).IsRequired().HasColumnType("decimal(18,2)");
            builder.Property(s => s.Discount).IsRequired().HasColumnType("decimal(18,2)");
            builder.Property(s => s.TotalPrice).IsRequired().HasColumnType("decimal(18,2)");
            builder.Property(s => s.IsCancelled).IsRequired().HasDefaultValue(false);
        }
    }
}
