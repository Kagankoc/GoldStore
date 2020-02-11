using GoldStore.Models.Addresses;
using GoldStore.Models.Orders;
using GoldStore.Models.Shared;
using System;
using System.Collections.Generic;

namespace GoldStore.Models.Customers
{
    public class Customer : BaseObject
    {
        public Guid PersonId { get; set; }

        public Person Person { get; set; }

        public IEnumerable<Order> Orders { get; set; }
        public IEnumerable<Address> Addresses { get; set; }
    }
}

