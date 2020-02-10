using GoldStore.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace GoldStore.Controllers
{
    public class CatalogController : Controller
    {
        private readonly ICatalogService _catalogService;
        private readonly ICartService _cartService;

        public CatalogController(ICatalogService catalogService, ICartService cartService)
        {
            _catalogService = catalogService;
            _cartService = cartService;
        }

        public IActionResult Index(string categorySlug = "all-categories", string brandSlug = "all-brands")
        {
            ViewData["SelectedCategory"] = categorySlug;
            ViewData["SelectedBrand"] = brandSlug;
            ViewData["OriginalUrl"] = "OriginalUrl";

            ViewData["CartTotal"] = _cartService.GetCartTotal();
            ViewData["CartItemsCount"] = _cartService.CartItemsCount();
            ViewData["CartItems"] = _cartService.GetCartItems();

            var pagedProducts = _catalogService.FetchProducts(categorySlug, brandSlug);

            return View(pagedProducts);
        }
    }
}