using GoldStore.Models.Address;
using System;
using System.Collections.Generic;

namespace GoldStore.Repository.Interfaces
{
    public interface IAddressRepository
    {
        Address FindAddressById(Guid id);
        IEnumerable<Address> GetAllAddresses();
        void SaveAddress(Address address);
        void UpdateAddress(Address address);
        void DeleteAddress(Address address);
    }
}