using GoldStore.Database;
using GoldStore.Models.Addresses;
using GoldStore.Repository.Interfaces;
using System;
using System.Collections.Generic;

namespace GoldStore.Repository.Classes
{
    public class AddressRepository : IAddressRepository
    {
        private readonly GoldStoreDbContext _context;

        public AddressRepository(GoldStoreDbContext context)
        {
            _context = context;
        }

        public Address FindAddressById(Guid id)
        {
            return _context.Addresses.Find(id);
        }

        public IEnumerable<Address> GetAllAddresses()
        {
            return _context.Addresses;
        }

        public void SaveAddress(Address address)
        {
            _context.Addresses.Add(address);
            _context.SaveChanges();
        }

        public void UpdateAddress(Address address)
        {
            _context.Addresses.Update(address);
            _context.SaveChanges();
        }

        public void DeleteAddress(Address address)
        {
            _context.Addresses.Remove(address);
            _context.SaveChanges();
        }
    }
}
