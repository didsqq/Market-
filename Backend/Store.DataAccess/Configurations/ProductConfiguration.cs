using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Store.DataAccess.Entities;
using Store.Core.Models;

namespace Store.DataAccess.Configuration
{
    public class ProductConfiguration : IEntityTypeConfiguration<ProductEntity>
    {
        public void Configure(EntityTypeBuilder<ProductEntity> builder)
        {
            builder.HasKey(x => x.Id);

            builder
                .HasOne(a => a.Image)
                .WithOne(c => c.Product);
                
            builder.Property(b => b.Title)
                .HasMaxLength(Product.MAX_TITLE_LENGTH)
                .IsRequired();
            builder.Property(b => b.Description)
                .IsRequired();
            builder.Property(b => b.Price)
                .IsRequired();
        }
    }
}