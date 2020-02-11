using GoldStore.Models.Orders;
using System;
using System.Collections.Generic;

namespace GoldStore.Repository.Interfaces
{
    public interface IOrderRepository
    {
        Order FindOrderById(Guid id);
        IEnumerable<Order> GetAllOrdersByCustomerId(Guid customerId);
        IEnumerable<Order> GetAllOrders();
        void SaveOrder(Order order);
        void UpdateOrder(Order order);
        void DeleteOrder(Order order);
    }
}