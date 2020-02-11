using GoldStore.Database;
using GoldStore.Models.Orders;
using GoldStore.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GoldStore.Repository.Classes
{
    public class OrderRepository : IOrderRepository
    {
        private readonly GoldStoreDbContext _context;

        public OrderRepository(GoldStoreDbContext context)
        {
            _context = context;
        }

        public Order FindOrderById(Guid id)
        {
            return _context.Orders.Find(id);
        }

        public IEnumerable<Order> GetAllOrdersByCustomerId(Guid customerId)
        {
            return _context.Orders.Where(x => x.CustomerId == customerId).ToList();
        }

        public IEnumerable<Order> GetAllOrders()
        {
            return _context.Orders;
        }

        public void SaveOrder(Order order)
        {
            _context.Orders.Add(order);
            _context.SaveChanges();
        }

        public void UpdateOrder(Order order)
        {
            _context.Orders.Update(order);
            _context.SaveChanges();

        }

        public void DeleteOrder(Order order)
        {
            _context.Orders.Remove(order);
            _context.SaveChanges();
        }
    }
}
