using XP.Hackathon.Zabbot.Model;
using XP.Hackathon.Zabbot.Model.Configuration;
using Microsoft.EntityFrameworkCore;

namespace XP.Hackathon.Zabbot.Infrastructure.Data.Context
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options)
        : base(options)
        {

        }

        public DbSet<User> User { get; set; }
        public DbSet<Product> Product { get;set;}
        public DbSet<EscalationGroup> EscalationGroup { get; set; }
        public DbSet<Escalation> Escalation { get; set; }

        // SkyNet.Region create_table

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(AppSettings.ConnectionString.Zabbot);
        }
    }
}

