using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using RhythmsGonnaGetYou.bin;

namespace RhythmsGonnaGetYou
{
    public class RecordLabelContext : DbContext
    {
        public DbSet<Albums> Albums { get; set; }
        public DbSet<Bands> Bands { get; set; }
        public DbSet<Songs> Songs { get; set; }
        public DbSet<Musicians> Musicians { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Testing
            // var loggerFactory = LoggerFactory.Create(builder => builder.AddConsole());
            // optionsBuilder.UseLoggerFactory(loggerFactory);

            optionsBuilder.UseNpgsql("server = localhost; database = RecordsDatabase"); // Connects to Db
        }

    }
}