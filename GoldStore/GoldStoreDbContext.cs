using GoldStore.Models.Products;
using Microsoft.EntityFrameworkCore;


namespace GoldStore
{
    public class GoldStoreDbContext : DbContext
    {
        public GoldStoreDbContext(DbContextOptions<GoldStoreDbContext> options) : base(options)
        {

        }

        public DbSet<Brand> Brands { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
}
