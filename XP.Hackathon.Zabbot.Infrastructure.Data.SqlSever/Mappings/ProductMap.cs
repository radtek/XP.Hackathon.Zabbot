using XP.Hackathon.Zabbot.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace XP.Hackathon.Zabbot.Infrastructure.Data.SqlSever.Mappings
{
    public class ProductMap : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Product");

            builder.Property(c => c.Id).HasColumnName("Id");
            builder.Property(c => c.SinapiId).HasColumnName("SinapiId");
            builder.Property(c => c.Name).HasColumnName("Name");
            builder.Property(c => c.Unity).HasColumnName("Unity");
            builder.Property(c => c.AveragePrice).HasColumnName("AveragePrice");
            builder.Property(c => c.Created).HasColumnName("Created");
            builder.Property(c => c.Updated).HasColumnName("Updated");
            builder.Property(c => c.Active).HasColumnName("Active");
        }
    }
}

