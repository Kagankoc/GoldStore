using GoldStore.Models.Cart;
using System;
using System.Collections.Generic;

namespace GoldStore.Repository.Interfaces
{
    public interface ICartRepository
    {
        Cart FindCartById(Guid id);
        IEnumerable<Cart> GetAllCarts();
        void SaveCart(Cart cart);
        void UpdateCart(Cart cart);
        void DeleteCart(Cart cart);
    }
}