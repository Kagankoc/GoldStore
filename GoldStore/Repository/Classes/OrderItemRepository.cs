using GoldStore.Database;
using GoldStore.Models.Orders;
using GoldStore.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GoldStore.Repository.Classes
{
    public class OrderItemRepository : IOrderItemRepository
    {
        private readonly GoldStoreDbContext _context;

        public OrderItemRepository(GoldStoreDbContext context)
        {
            _context = context;
        }

        public OrderItem FindOrderItemById(Guid id)
        {
            return _context.OrderItems.Find(id);
        }

        public IEnumerable<OrderItem> GetAllOrderItemsByOrderId(Guid orderId)
        {
            return _context.OrderItems.Where(x => x.OrderId == orderId).ToList();
        }

        public IEnumerable<OrderItem> GetAllOrders()
        {
            return _context.OrderItems;
        }

        public void SaveOrderItem(OrderItem orderItem)
        {
            _context.OrderItems.Add(orderItem);
            _context.SaveChanges();
        }

        public void UpdateOrderItem(OrderItem orderItem)
        {
            _context.OrderItems.Update(orderItem);
            _context.SaveChanges();
        }

        public void DeleteOrderItem(OrderItem orderItem)
        {
            _context.OrderItems.Remove(orderItem);
            _context.SaveChanges();
        }

    }
}
