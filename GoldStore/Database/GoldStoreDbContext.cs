using GoldStore.Models.Addresses;
using GoldStore.Models.Carts;
using GoldStore.Models.Customers;
using GoldStore.Models.Orders;
using GoldStore.Models.Products;
using GoldStore.Models.Shared;
using Microsoft.EntityFrameworkCore;

namespace GoldStore.Database
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
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Person> People { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }

    }
}
