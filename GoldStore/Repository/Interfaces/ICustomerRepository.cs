using GoldStore.Models.Customers;
using System;
using System.Collections.Generic;

namespace GoldStore.Repository.Interfaces
{
    public interface ICustomerRepository
    {
        Customer FindCustomerById(Guid id);
        IEnumerable<Customer> GetAllCustomers();
        void SaveCustomer(Customer customer);
        void UpdateCustomer(Customer customer);
        void DeleteCustomer(Customer customer);
    }
}