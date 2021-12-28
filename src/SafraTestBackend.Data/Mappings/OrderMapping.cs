using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SafraTestBackend.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SafraTestBackend.Data.Mappings
{
    public class OrderMapping : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Price)
                .IsRequired()
                .HasColumnType("decimal(18, 4)");

            builder.Property(p => p.Quantity)
                .IsRequired()
                .HasColumnType("decimal(18, 4)");

            builder.Property(p => p.ValueService)
                .IsRequired()
                .HasColumnType("decimal(18, 4)");

            builder.Property(p => p.TaxService)
                .IsRequired()
                .HasColumnType("decimal(18, 4)");

            builder.ToTable("Orders");

            
        }
    }
}
