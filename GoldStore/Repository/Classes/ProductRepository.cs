using System;
using System.Collections.Generic;
using GoldStore.Models.Products;
using GoldStore.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace GoldStore.Repository.Classes
{
    public class ProductRepository : IProductRepository
    {
        private readonly GoldStoreDbContext _context;

        public ProductRepository(GoldStoreDbContext context)
        {
            _context = context;
        }

        public Product FindByProductId(Guid id)
        {
            return _context.Products.Find(id);
        }

        public IEnumerable<Product> GetAllProducts()
        {
            var products =
                _context.Products
                    .Include(p => p.Category)
                    .Include(p => p.Brand);
            return products;
        }

        public void SaveProduct(Product product)
        {
            _context.Products.Add(product);
            _context.SaveChanges();

        }

        public void UpdateProduct(Product product)
        {
            _context.Products.Update(product);
            _context.SaveChanges();
        }

        public void DeleteProduct(Product product)
        {
            _context.Products.Remove(product);
            _context.SaveChanges();
        }
    }
}
