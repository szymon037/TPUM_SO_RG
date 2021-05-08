using System;
using System.Collections.Generic;
using System.Text;

using Data.Collections;
using Data.Models;

namespace LogicTests
{
    class ImpUserCollection : ILibraryCollection<IUser>
    {
        List<IUser> users;

        public ImpUserCollection()
        {
            users = new List<IUser>();
        }

        public IUser Add(IUser entity)
        {
            users.Add(entity);
            return entity;
        }

        public void Delete(int id)
        {
        }

        public IEnumerable<IUser> Get()
        {
            return users;
        }

        public IEnumerable<IUser> Get(Predicate<IUser> pred)
        {
            return null;
        }

        public IUser Get(int id)
        {
            return users.Find(c => c.ID == id);
        }

        public IUser Update(IUser entity)
        {
            var us = Get(entity.ID);
            us.Name = entity.Name;
            us.Address = entity.Address;

            return us;
        }
    }
}
