using System;
using System.Collections.Generic;
using GoldStore.Models.Products;
using GoldStore.Repository.Interfaces;

namespace GoldStore.Repository.Classes
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly GoldStoreDbContext _context;

        public CategoryRepository(GoldStoreDbContext context)
        {
            _context = context;
        }

        public Category GetCategoryById(Guid id)
        {
            return _context.Categories.Find(id);
        }

        public IEnumerable<Category> GetAllCategories()
        {
            return _context.Categories;
        }

        public void SaveCategory(Category category)
        {
            _context.Categories.Add(category);
            _context.SaveChanges();
        }

        public void UpdateCategory(Category category)
        {
            _context.Categories.Update(category);
            _context.SaveChanges();
        }

        public void DeleteCategory(Category category)
        {
            _context.Categories.Remove(category);
            _context.SaveChanges();
        }
    }
}
