using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Store.DataAccess.Entities;

namespace Store.DataAccess.Configuration
{
    public class ImageConfiguration : IEntityTypeConfiguration<ImageEntity>
    {
        public void Configure(EntityTypeBuilder<ImageEntity> builder)
        {
            builder.HasKey(x => x.Id);

            builder
                .HasOne(a => a.Product)
                .WithOne(c => c.Image)
                .HasForeignKey<ImageEntity>(i => i.ProductId);

            builder.Property(b => b.FileName)
                .IsRequired();
        }
    }
}