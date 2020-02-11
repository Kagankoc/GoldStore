using GoldStore.Database;
using GoldStore.Models.Carts;
using GoldStore.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GoldStore.Repository.Classes
{
    public class CartItemRepository : ICartItemRepository
    {
        private readonly GoldStoreDbContext _context;

        public CartItemRepository(GoldStoreDbContext context)
        {
            _context = context;
        }

        public CartItem FindCartItemById(Guid id)
        {
            return _context.CartItems.Find(id);
        }

        public IEnumerable<CartItem> FindCartItemsByCartId(Guid CartId)
        {
            return _context.CartItems.Where(x => x.CartId == CartId);
        }

        public void SaveCartItem(CartItem cartItem)
        {
            _context.CartItems.Add(cartItem);
            _context.SaveChanges();
        }

        public void UpdateCartItem(CartItem cartItem)
        {
            _context.CartItems.Update(cartItem);
            _context.SaveChanges();
        }

        public void DeleteCartItem(CartItem cartItem)
        {
            _context.CartItems.Remove(cartItem);
            _context.SaveChanges();
        }
    }
}
