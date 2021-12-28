using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SafraTestBackend.Domain.Entities;

namespace SafraTestBackend.Data.Mappings
{
    public class StocksMapping : IEntityTypeConfiguration<Stocks>
    {
        public void Configure(EntityTypeBuilder<Stocks> builder)
        {
            builder.HasKey(p => p.Id);

            builder.HasIndex(p => p.Symbol);

            builder.Property(p => p.Symbol)    
                .IsRequired()
                .HasColumnType("varchar(10)");

            builder.Property(p => p.Name)
                .IsRequired()
                .HasColumnType("varchar(50)");

            builder.ToTable("Stocks");
        }
    }

}
