using GoldStore.Models.Carts;
using System;
using System.Collections.Generic;

namespace GoldStore.Repository.Interfaces
{
    public interface ICartItemRepository
    {
        CartItem FindCartItemById(Guid id);
        IEnumerable<CartItem> FindCartItemsByCartId(Guid CartId);
        void SaveCartItem(CartItem cartItem);
        void UpdateCartItem(CartItem cartItem);
        void DeleteCartItem(CartItem cartItem);
    }
}