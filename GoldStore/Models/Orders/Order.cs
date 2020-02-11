using GoldStore.Models.Addresses;
using GoldStore.Models.Customers;
using GoldStore.Models.Shared;
using System;
using System.Collections.Generic;

namespace GoldStore.Models.Orders
{
    public class Order : BaseObject
    {
        public double OrderTotal { get; set; }
        public double OrderItemTotal { get; set; }
        public double ShippingCharge { get; set; }
        public Guid CustomerId { get; set; }
        public Customer Customer { get; set; }
        public OrderStatus OrderStatus { get; set; }
        public Guid AddressId { get; set; }
        public Address DeliveryAddress { get; set; }

        public IEnumerable<OrderItem> OrderItems { get; set; }
    }
}
