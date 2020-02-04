using System.Collections.Generic;
using GoldStore.Models.Products;

namespace GoldStore.ViewModels.Catalog
{
    public class PaginationViewModel
    {
        public IEnumerable<Product> Products { get; set; }
        public bool HasPreviousPages { get; set; }
        public int CurrentPage { get; set; }
        public bool HasNextPages { get; set; }
        public int[] Pages { get; set; }
    }
}
