using GoldStore.Models.Cart;
using GoldStore.ViewModels.Cart;
using System.Collections.Generic;

namespace GoldStore.Services.Interfaces
{
    public interface ICartService
    {
        string UniqueCartId();
        Cart GetCart();
        void AddToCart(AddToCartViewModel addToCartViewModel);
        void RemoveFromCart(RemoveFromCartViewModel removeFromCartViewModel);
        IEnumerable<CartItem> GetCartItems();
        int CartItemsCount();
        double GetCartTotal();
    }
}