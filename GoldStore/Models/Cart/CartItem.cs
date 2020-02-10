﻿using GoldStore.Models.Products;
using GoldStore.Models.Shared;
using System;

namespace GoldStore.Models.Cart
{
    public class CartItem : BaseObject
    {
        public Guid CartId { get; set; }
        public Cart Cart { get; set; }
        public Guid ProductId { get; set; }
        public Product Product { get; set; }
        public int Quantity { get; set; }
    }
}
