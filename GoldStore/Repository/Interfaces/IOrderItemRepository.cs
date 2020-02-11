using GoldStore.Models.Orders;
using System;
using System.Collections.Generic;

namespace GoldStore.Repository.Interfaces
{
    public interface IOrderItemRepository
    {
        OrderItem FindOrderItemById(Guid id);
        IEnumerable<OrderItem> GetAllOrderItemsByOrderId(Guid orderId);
        IEnumerable<OrderItem> GetAllOrders();
        void SaveOrderItem(OrderItem orderItem);
        void UpdateOrderItem(OrderItem orderItem);
        void DeleteOrderItem(OrderItem orderItem);
    }
}