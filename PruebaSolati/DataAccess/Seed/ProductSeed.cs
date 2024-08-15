using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Seed
{
    public class ProductSeed : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasData(
                new Product { Id = 1, Name="test1", Code = 123, Picture = "string", Price = 123, CreationDate = DateTime.UtcNow },
                new Product { Id = 2, Name = "test2", Code =123, Picture = "string", Price = 123, CreationDate = DateTime.UtcNow },
                new Product { Id = 3, Name = "test3", Code =123, Picture = "string", Price = 123, CreationDate = DateTime.UtcNow },
                new Product { Id = 4, Name = "test4", Code=123, Picture = "string", Price = 123, CreationDate = DateTime.UtcNow }
            );
        }
    }
}
