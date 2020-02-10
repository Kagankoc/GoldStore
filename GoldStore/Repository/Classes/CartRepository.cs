using GoldStore.Models.Cart;
using GoldStore.Repository.Interfaces;
using System;
using System.Collections.Generic;

namespace GoldStore.Repository.Classes
{
    public class CartRepository : ICartRepository
    {
        private readonly GoldStoreDbContext _context;

        public CartRepository(GoldStoreDbContext context)
        {
            _context = context;
        }

        public Cart FindCartById(Guid id)
        {
            var cart = _context.Carts.Find(id);
            return cart;

        }

        public IEnumerable<Cart> GetAllCarts()
        {
            return _context.Carts;
        }

        public void SaveCart(Cart cart)
        {
            _context.Carts.Add(cart);
            _context.SaveChanges();
        }

        public void UpdateCart(Cart cart)
        {
            _context.Carts.Update(cart);
            _context.SaveChanges();
        }

        public void DeleteCart(Cart cart)
        {
            _context.Carts.Remove(cart);
            _context.SaveChanges();
        }

    }
}
