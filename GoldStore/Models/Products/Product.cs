using GoldStore.Models.Shared;
using System;

namespace GoldStore.Models.Products
{
    public class Product : BaseObject
    {
        public string Name { get; set; }
        public string Slug { get; set; }
        public string Description { get; set; }
        public string MetaDescription { get; set; }
        public string MetaKeywords { get; set; }
        public string SKU { get; set; }
        public string Model { get; set; }
        public double Price { get; set; }
        public double SalePrice { get; set; }
        public double OldPrice { get; set; }
        public string ImageUrl { get; set; }
        public int QuantityInStock { get; set; }
        public bool IsBestSeller { get; set; }
        public bool IsFeatured { get; set; }
        public Guid CategoryId { get; set; }
        public Category Category { get; set; }
        public Guid BrandId { get; set; }
        public Brand Brand { get; set; }
        public ProductStatus ProductStatus { get; set; }

    }
}
