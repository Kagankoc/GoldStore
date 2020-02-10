using GoldStore.Models.Products;
using GoldStore.Repository.Interfaces;
using System;
using System.Collections.Generic;

namespace GoldStore.Repository.Classes
{
    public class BrandRepository : IBrandRepository
    {
        private readonly GoldStoreDbContext _context;

        public BrandRepository(GoldStoreDbContext context)
        {
            _context = context;
        }

        public Brand GetBrandById(Guid id)
        {
            return _context.Brands.Find(id);
        }

        public IEnumerable<Brand> GetAllBrands()
        {
            return _context.Brands;
        }

        public void SaveBrand(Brand brand)
        {
            _context.Brands.Add(brand);
            _context.SaveChanges();
        }

        public void UpdateBrand(Brand brand)
        {
            _context.Brands.Update(brand);
            _context.SaveChanges();
        }

        public void DeleteBrand(Brand brand)
        {
            _context.Brands.Remove(brand);
            _context.SaveChanges();
        }
    }
}
