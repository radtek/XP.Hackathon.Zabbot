using XP.Hackathon.Zabbot.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace XP.Hackathon.Zabbot.Infrastructure.Data.SqlSever.Mappings
{
    public class EscalationGroupMap : IEntityTypeConfiguration<EscalationGroup>
    {
        public void Configure(EntityTypeBuilder<EscalationGroup> builder)
        {
            builder.ToTable("EscalationGroup");

            builder.Property(c => c.Id).HasColumnName("Id");
            builder.Property(c => c.Name).HasColumnName("Name");
            builder.Property(c => c.Email).HasColumnName("Email");
            builder.Property(c => c.TagName).HasColumnName("TagName");
            builder.Property(c => c.Created).HasColumnName("Created");
            builder.Property(c => c.Updated).HasColumnName("Updated");
            builder.Property(c => c.Active).HasColumnName("Active");
        }
    }
}
