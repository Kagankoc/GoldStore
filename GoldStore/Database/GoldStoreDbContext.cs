using GoldStore.Models.Address;
using GoldStore.Models.Cart;
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

        public DbSet<Cart> Carts { get; set; }
        public DbSet<CartItem> CartItems { get; set; }
        public DbSet<Address> Addresses { get; set; }

    }
}
