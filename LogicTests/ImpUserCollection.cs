using System;
using System.Collections.Generic;
using System.Text;

using Data.Collections;
using Data.Models;

namespace LogicTests
{
    class ImpUserCollection : ILibraryCollection<User>
    {
        List<User> users;

        public ImpUserCollection()
        {
            users = new List<User>();
        }

        public User Add(User entity)
        {
            users.Add(entity);
            return entity;
        }

        public void Delete(int id)
        {
        }

        public IEnumerable<User> Get()
        {
            return users;
        }

        public IEnumerable<User> Get(Predicate<User> pred)
        {
            return null;
        }

        public User Get(int id)
        {
            return users.Find(c => c.ID == id);
        }

        public User Update(User entity)
        {
            var us = Get(entity.ID);
            us.Name = entity.Name;
            us.Address = entity.Address;

            return us;
        }
    }
}
