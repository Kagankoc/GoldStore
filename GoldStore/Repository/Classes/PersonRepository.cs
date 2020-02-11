using GoldStore.Database;
using GoldStore.Models.Shared;
using GoldStore.Repository.Interfaces;
using System;
using System.Collections.Generic;

namespace GoldStore.Repository.Classes
{
    public class PersonRepository : IPersonRepository
    {
        private readonly GoldStoreDbContext _context;

        public PersonRepository(GoldStoreDbContext context)
        {
            _context = context;
        }

        public Person FindPersonById(Guid id)
        {
            return _context.People.Find(id);
        }

        public IEnumerable<Person> FindPeople()
        {
            return _context.People;
        }
        public void SavePerson(Person person)
        {
            _context.People.Add(person);
            _context.SaveChanges();
        }

        public void UpdatePerson(Person person)
        {
            _context.People.Update(person);
            _context.SaveChanges();
        }

        public void DeletePerson(Person person)
        {
            _context.People.Remove(person);
            _context.SaveChanges();
        }
    }
}
