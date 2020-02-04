using GoldStore.Models.Products;
using GoldStore.Repository.Interfaces;
using GoldStore.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using GoldStore.ViewModels.Catalog;

namespace GoldStore.Services.Classes
{
    public class CatalogService : ICatalogService
    {
        private readonly HttpContext _httpContext;
        private readonly IBrandRepository _brandRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IProductRepository _productRepository;
        private const int _productPerPage = 9;

        public CatalogService(IHttpContextAccessor httpContextAccessor,
            IBrandRepository brandRepository,
            ICategoryRepository categoryRepository,
            IProductRepository productRepository)
        {
            _httpContext = httpContextAccessor.HttpContext;
            _brandRepository = brandRepository;
            _categoryRepository = categoryRepository;
            _productRepository = productRepository;
        }

        public PagedProductViewModel FetchProducts(string categorySlug, string brandSlug)
        {
            var brands = _brandRepository.GetAllBrands().Where(brand => brand.IsDeleted == false);
            var categories = _categoryRepository.GetAllCategories().Where(category => category.IsDeleted == false);

            var productPage = GetCurrentPage();

            IEnumerable<Product> products = new List<Product>();
            var productCount = 0;


            productCount = GetProducts(categorySlug, brandSlug, productPage, out products);


            var totalPages = (int)Math.Ceiling((decimal)productCount / _productPerPage);

            int[] pages = Enumerable.Range(1, totalPages).ToArray();

            var pagedProduct = new PaginationViewModel
            {
                Products = products,
                HasPreviousPages = (productPage > 1),
                CurrentPage = productPage,
                HasNextPages = (productPage < totalPages),
                Pages = pages
            };
            var pagedProducts = new PagedProductViewModel
            {
                PagedProducts = pagedProduct,
                Brands = brands,
                Categories = categories
            };

            return pagedProducts;
        }
        public int GetCurrentPage()
        {
            var defaultPage = 1;
            if (_httpContext.Request.Path.HasValue)
            {
                var pathValues = _httpContext.Request.Path.Value.Split('/');
                var pageFragment = pathValues[pathValues.Length - 1];

                if (!string.IsNullOrWhiteSpace(pageFragment) && pageFragment.Contains("page")) //page4
                {
                    var pageNumber = pageFragment.Last().ToString();
                    defaultPage = Convert.ToInt32(pageNumber);
                }
            }
            return defaultPage;
        }



        //Private Methods For FetchProduct Job
        private int GetProducts(string categorySlug, string brandSlug, int productPage, out IEnumerable<Product> products)
        {
            int productCount;
            if (categorySlug == "all-categories")
            {
                productCount = brandSlug == "all-brands"
                    ? GetAllProducts(productPage, out products)
                    : GetFilteredProductsWithBrand(brandSlug, productPage, out products);
            }
            else
            {
                productCount = brandSlug == "all-brands"
                    ? GetFilteredProductWithCategory(categorySlug, productPage, out products)
                    : GetFilteredProductWithBrandAndCategory(brandSlug, categorySlug, productPage, out products);
            }

            return productCount;
        }

        private int GetFilteredProductWithBrandAndCategory(string brandSlug, string categorySlug, int productPage, out IEnumerable<Product> products)
        {
            var filteredProducts = _productRepository.GetAllProducts()
                .Where(product => product.ProductStatus == ProductStatus.Active &&
                                  product.Category.Slug == categorySlug &&
                                  product.Brand.Slug == brandSlug);
            var productCount = filteredProducts.Count();
            products = filteredProducts
                .Skip((productPage - 1) * _productPerPage)
                .Take(_productPerPage);
            return productCount;
        }

        private int GetFilteredProductWithCategory(string categorySlug, int productPage, out IEnumerable<Product> products)
        {
            var filteredProducts = _productRepository.GetAllProducts()
                .Where(product => product.ProductStatus == ProductStatus.Active &&
                                  product.Category.Slug == categorySlug);
            var productCount = filteredProducts.Count();
            products = filteredProducts.Skip((productPage - 1) * _productPerPage)
                .Take(_productPerPage);
            return productCount;
        }

        private int GetFilteredProductsWithBrand(string brandSlug, int productPage, out IEnumerable<Product> products)
        {
            var filteredProducts = _productRepository.GetAllProducts()
                .Where(product => product.ProductStatus == ProductStatus.Active &&
                                  product.Brand.Slug == brandSlug);
            var productCount = filteredProducts.Count();
            products = filteredProducts.Skip((productPage - 1) * _productPerPage)
                .Take(_productPerPage);
            return productCount;
        }

        private int GetAllProducts(int productPage, out IEnumerable<Product> products)
        {
            var productCount = _productRepository.GetAllProducts().Count();
            products = _productRepository.GetAllProducts()
                .Where(product => product.ProductStatus == ProductStatus.Active)
                .Skip((productPage - 1) * _productPerPage)
                .Take(_productPerPage);
            return productCount;
        }

       

    }
}
