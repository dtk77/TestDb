using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using TestDb.ApplicationCore;

namespace TestDb.Infrastructure.Config
{
    internal class ProductConfiguration : IEntityTypeConfiguration<Product>
    {

        public void Configure(EntityTypeBuilder<Product> builder)
        {

            builder.ToTable("Product");

           /* builder.Property(p => p.ProductID)
                .HasColumnName("Id")
                .IsRequired();*/

            builder.Property(p => p.Name)
                .HasMaxLength(255)
                .IsRequired();
        }

    }
}
