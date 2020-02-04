using GoldStore.Models.Products;
using System.Collections.Generic;

namespace GoldStore.ViewModels.Catalog
{
    public class PagedProductViewModel
    {
        public PaginationViewModel PagedProducts { get; set; }
        public IEnumerable<Brand> Brands { get; set; }
        public IEnumerable<Category> Categories { get; set; }
    }
}
