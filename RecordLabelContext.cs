using Microsoft.EntityFrameworkCore;
using RhythmsGonnaGetYou.bin;

namespace RhythmsGonnaGetYou
{
    public class RecordLabelContext : DbContext
    {
        public DbSet<Album> Albums { get; set; }
        public DbSet<Band> Bands { get; set; }
        public DbSet<Song> Songs { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // var loggerFactory = LoggerFactory.Create(builder => builder.AddConsole());
            // optionsBuilder.UseLoggerFactory(loggerFactory);
            optionsBuilder.UseNpgsql("server=localhost;database=RecordLabelDatabase"); // Connects to Db
        }

    }
}