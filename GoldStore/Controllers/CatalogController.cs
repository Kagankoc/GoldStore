using GoldStore.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace GoldStore.Controllers
{
    public class CatalogController : Controller
    {
        private readonly ICatalogService _catalogService;

        public CatalogController(ICatalogService catalogService)
        {
            _catalogService = catalogService;
        }

        public IActionResult Index(string categorySlug = "all-categories", string brandSlug = "all-brands")
        {
            ViewData["SelectedCategory"] = categorySlug;
            ViewData["SelectedBrand"] = brandSlug;
            ViewData["OriginalUrl"] = "OriginalUrl";

            var pagedProducts = _catalogService.FetchProducts(categorySlug, brandSlug);

            return View(pagedProducts);
        }
    }
}