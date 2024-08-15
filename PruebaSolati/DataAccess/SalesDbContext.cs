using DataAccess.Entities;
using DataAccess.Seed;
using Microsoft.EntityFrameworkCore;

namespace DataAccess
{
    public class SalesDbContext : DbContext
    {

        public SalesDbContext(DbContextOptions<SalesDbContext> options) : base(options)
        {

        }
        public virtual DbSet<Product> Products { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        { 
            modelBuilder.ApplyConfiguration(new ProductSeed());
        }

    }
}
