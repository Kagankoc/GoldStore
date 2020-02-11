using GoldStore.ViewModels.Checkout;

namespace GoldStore.Services.Interfaces
{
    public interface ICheckoutService
    {
        void ProcessCheckout(CheckoutViewModel checkoutViewModel);
    }
}