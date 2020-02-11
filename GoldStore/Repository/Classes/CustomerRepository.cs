using GoldStore.Database;
using GoldStore.Models.Customers;
using GoldStore.Repository.Interfaces;
using System;
using System.Collections.Generic;

namespace GoldStore.Repository.Classes
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly GoldStoreDbContext _context;

        public CustomerRepository(GoldStoreDbContext context)
        {
            _context = context;
        }

        public Customer FindCustomerById(Guid id)
        {
            return _context.Customers.Find(id);
        }

        public IEnumerable<Customer> GetAllCustomers()
        {
            return _context.Customers;
        }

        public void SaveCustomer(Customer customer)
        {
            _context.Customers.Add(customer);
            _context.SaveChanges();
        }

        public void UpdateCustomer(Customer customer)
        {
            _context.Customers.Update(customer);
            _context.SaveChanges();
        }

        public void DeleteCustomer(Customer customer)
        {
            _context.Customers.Remove(customer);
            _context.SaveChanges();
        }
    }
}
