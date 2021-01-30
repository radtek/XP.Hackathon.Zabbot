using XP.Hackathon.Zabbot.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace XP.Hackathon.Zabbot.Infrastructure.Data.SqlSever.Mappings
{
    public class EscalationMap : IEntityTypeConfiguration<Escalation>
    {
        public void Configure(EntityTypeBuilder<Escalation> builder)
        {
            builder.ToTable("Escalation");

            builder.Property(c => c.Id).HasColumnName("Id");
            builder.Property(c => c.GroupId).HasColumnName("GroupId");
            builder.Property(c => c.Sequence).HasColumnName("Sequence");
            builder.Property(c => c.HourStart).HasColumnName("HourStart");
            builder.Property(c => c.HourEnd).HasColumnName("HourEnd");
            builder.Property(c => c.Role).HasColumnName("Role");
            builder.Property(c => c.Name).HasColumnName("Name");
            builder.Property(c => c.Contact).HasColumnName("Contact");
            builder.Property(c => c.Email).HasColumnName("Email");
            builder.Property(c => c.Note).HasColumnName("Note");
            builder.Property(c => c.Created).HasColumnName("Created");
            builder.Property(c => c.Updated).HasColumnName("Updated");
            builder.Property(c => c.Active).HasColumnName("Active");
        }
    }
}
