using Microsoft.EntityFrameworkCore;
using PriceListEditor.Models;

namespace PriceListEditor.Persistence.DbContexts
{
    public class DbContextSqlite : DbContext
    {
        public DbSet<PriceList> PriceLists { get; set; } = null!;
        public DbSet<Product> Products { get; set; } = null!;
        public DbSet<Feature> Features { get; set; } = null!;
        public DbSet<ProductFeature> ProductFeatures { get; set; } = null!;

        public DbContextSqlite(DbContextOptions<DbContextSqlite> options) : base(options)
        {
        }

        public DbContextSqlite()
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=data.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder
            .Entity<Feature>()
            .Property(e => e.Type)
            .HasConversion<string>();
        }

    }
}
