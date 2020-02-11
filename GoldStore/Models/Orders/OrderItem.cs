using GoldStore.Models.Products;
using GoldStore.Models.Shared;
using System;

namespace GoldStore.Models.Orders
{
    public class OrderItem : BaseObject
    {
        public Guid OrderId { get; set; }
        public Orders.Order Order { get; set; }
        public Guid ProductId { get; set; }
        public Product Product { get; set; }
        public int Quantity { get; set; }

    }
}
