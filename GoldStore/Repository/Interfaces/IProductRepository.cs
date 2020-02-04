using System;
using System.Collections.Generic;
using GoldStore.Models.Products;

namespace GoldStore.Repository.Interfaces
{
    public interface IProductRepository
    {
        Product FindByProductId(Guid id);
        IEnumerable<Product> GetAllProducts();
        void SaveProduct(Product product);
        void UpdateProduct(Product product);
        void DeleteProduct(Product product);
    }
}