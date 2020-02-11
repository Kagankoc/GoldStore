using GoldStore.Services.Interfaces;
using GoldStore.ViewModels.Checkout;
using Microsoft.AspNetCore.Mvc;

namespace GoldStore.Controllers
{
    public class CheckoutController : Controller
    {
        private readonly ICheckoutService _checkoutService;

        public CheckoutController(ICheckoutService checkoutService)
        {
            _checkoutService = checkoutService;
        }

        [HttpGet]
        public IActionResult Checkout()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Checkout(CheckoutViewModel checkoutViewModel)
        {
            _checkoutService.ProcessCheckout(checkoutViewModel);
            return RedirectToAction("Receipt");
        }

        public IActionResult Receipt()
        {
            return View();
        }
    }
}