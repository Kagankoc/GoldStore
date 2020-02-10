using Microsoft.AspNetCore.Mvc;

namespace GoldStore.Controllers
{
    public class CheckoutController : Controller
    {
        public IActionResult Checkout()
        {
            return View();
        }
    }
}