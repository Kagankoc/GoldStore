using GoldStore.Models.Shared;
using System;
using System.Collections.Generic;

namespace GoldStore.Repository.Interfaces
{
    public interface IPersonRepository
    {
        Person FindPersonById(Guid id);
        IEnumerable<Person> FindPeople();
        void SavePerson(Person person);
        void UpdatePerson(Person person);
        void DeletePerson(Person person);
    }
}