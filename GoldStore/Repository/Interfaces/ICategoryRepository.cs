using System;
using System.Collections.Generic;
using GoldStore.Models.Products;

namespace GoldStore.Repository.Interfaces
{
    public interface ICategoryRepository
    {
        Category GetCategoryById(Guid id);
        IEnumerable<Category> GetAllCategories();
        void SaveCategory(Category category);
        void UpdateCategory(Category category);
        void DeleteCategory(Category category);
    }
}