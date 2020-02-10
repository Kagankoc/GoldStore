using System;

namespace GoldStore.ViewModels.Cart
{
    public class AddToCartViewModel
    {
        public Guid ProductId { get; set; }
        public string CategorySlug { get; set; }
        public string BrandSlug { get; set; }
        public string Page { get; set; }
    }
}
