﻿using GoldStore.Models.Carts;
using GoldStore.Repository.Interfaces;
using GoldStore.Services.Interfaces;
using GoldStore.ViewModels.Cart;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GoldStore.Services.Classes
{
    public class CartService : ICartService
    {
        private readonly HttpContext _httpContext;
        private readonly ICartRepository _cartRepository;
        private readonly ICartItemRepository _cartItemRepository;
        private readonly IProductRepository _productRepository;
        private const string UniqueCartIdSessionKey = "UniqueCartId";

        public CartService(IHttpContextAccessor httpContextAccessor, ICartRepository cartRepository, ICartItemRepository cartItemRepository, IProductRepository productRepository)
        {
            _httpContext = httpContextAccessor.HttpContext;
            _cartRepository = cartRepository;
            _cartItemRepository = cartItemRepository;
            _productRepository = productRepository;
        }

        public string UniqueCartId()
        {
            if (!string.IsNullOrWhiteSpace(_httpContext.Session.GetString(UniqueCartIdSessionKey)))
            {
                return _httpContext.Session.GetString(UniqueCartIdSessionKey);
            }
            else
            {
                var uniqueId = Guid.NewGuid().ToString();
                _httpContext.Session.SetString(UniqueCartIdSessionKey, uniqueId);
                return _httpContext.Session.GetString(UniqueCartIdSessionKey);
            }
        }

        public Cart GetCart()
        {
            return _cartRepository.GetAllCarts().FirstOrDefault(c => c.UniqueCartId == UniqueCartId());
        }

        public void AddToCart(AddToCartViewModel addToCartViewModel)
        {
            var cart = GetCart();

            if (cart != null)
            {
                var existingCartItem = _cartItemRepository.FindCartItemsByCartId(cart.Id)
                    .FirstOrDefault((c => c.ProductId == addToCartViewModel.ProductId));

                if (existingCartItem != null)
                {
                    existingCartItem.Quantity++;
                    _cartItemRepository.UpdateCartItem(existingCartItem);
                }
                else
                {
                    var product = _productRepository.FindByProductId(addToCartViewModel.ProductId);
                    if (product != null)
                    {
                        var cartItem = new CartItem()
                        {
                            CartId = cart.Id,
                            Cart = cart,
                            ProductId = addToCartViewModel.ProductId,
                            Product = product,
                            Quantity = 1

                        };
                        _cartItemRepository.SaveCartItem(cartItem);
                    }
                }

            }
            else
            {
                var product = _productRepository.FindByProductId(addToCartViewModel.ProductId);
                if (product != null)
                {
                    var newCart = new Cart()
                    {
                        UniqueCartId = UniqueCartId(),
                        CartStatus = CartStatus.Open
                    };

                    _cartRepository.SaveCart(newCart);

                    var cartItem = new CartItem()
                    {
                        Cart = newCart,
                        CartId = newCart.Id,
                        ProductId = addToCartViewModel.ProductId,
                        Product = product,
                        Quantity = 1
                    };
                    _cartItemRepository.SaveCartItem(cartItem);
                }
            }

        }

        public void RemoveFromCart(RemoveFromCartViewModel removeFromCartViewModel)
        {
            var cartItem = _cartItemRepository.FindCartItemById(removeFromCartViewModel.CartItemId);
            _cartItemRepository.DeleteCartItem(cartItem);
        }

        public IEnumerable<CartItem> GetCartItems()
        {
            IList<CartItem> cartItems = new List<CartItem>();
            var cart = GetCart();

            if (cart != null)
            {
                cartItems = _cartItemRepository.FindCartItemsByCartId(cart.Id).ToArray();
            }

            return cartItems;
        }

        public int CartItemsCount()
        {
            var count = 0;
            var cartItems = GetCartItems();
            foreach (var cartItem in cartItems)
            {
                count += cartItem.Quantity;
            }

            return count;
        }

        public double GetCartTotal()
        {
            double total = 0;
            var cartItems = GetCartItems();
            foreach (var cartItem in cartItems)
            {
                var product = _productRepository.FindByProductId(cartItem.ProductId);
                total += cartItem.Quantity * product.Price;
            }
            return total;

        }
    }
}
