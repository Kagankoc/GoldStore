using System;
using System.Collections.Generic;
using GoldStore.Models.Products;

namespace GoldStore.Repository.Interfaces
{
    public interface IBrandRepository
    {
        Brand GetBrandById(Guid id);
        IEnumerable<Brand> GetAllBrands();
        void SaveBrand(Brand brand);
        void UpdateBrand(Brand brand);
        void DeleteBrand(Brand brand);
    }
}