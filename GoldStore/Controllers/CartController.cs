using GoldStore.Services.Interfaces;
using GoldStore.ViewModels.Cart;
using Microsoft.AspNetCore.Mvc;

namespace GoldStore.Controllers
{


    public class CartController : Controller
    {
        private readonly ICartService _cartService;

        private bool AllCategoriesAndBrands(AddToCartViewModel addToCartViewModel)
        {
            return addToCartViewModel.CategorySlug == "all-categories" && addToCartViewModel.BrandSlug == "all-brands";
        }
        public CartController(ICartService cartService)
        {
            _cartService = cartService;
        }

        [HttpGet]
        public IActionResult CartDetail()
        {
            ViewData["CartTotal"] = _cartService.GetCartTotal();
            ViewData["CartItemsCount"] = _cartService.CartItemsCount();
            ViewData["CartItems"] = _cartService.GetCartItems();

            return View();
        }

        [HttpPost]
        public IActionResult RemoveCartItem(RemoveFromCartViewModel removeFromCartViewModel)
        {
            _cartService.RemoveFromCart(removeFromCartViewModel);
            return RedirectToAction("CartDetail");
        }

        [HttpPost]
        public IActionResult AddItemToCart(AddToCartViewModel addToCartViewModel)
        {
            _cartService.AddToCart(addToCartViewModel);

            if (AllCategoriesAndBrands(addToCartViewModel))
            {
                return RedirectToAction("Index", "Catalog",
                    new
                    {
                        categorySlug = "",
                        brandSlug = "",
                        page = addToCartViewModel.Page == "1" ? null : addToCartViewModel.Page
                    });
            }
            else
            {
                return RedirectToAction("Index", "Catalog",
                    new
                    {
                        categorySlug = addToCartViewModel.CategorySlug,
                        brandSlug = addToCartViewModel.BrandSlug,
                        page = addToCartViewModel.Page == "1" ? null : addToCartViewModel.Page
                    });
            }

        }

    }
}