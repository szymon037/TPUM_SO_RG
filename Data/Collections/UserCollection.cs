using System;
using System.Collections.Generic;

using Data;
using Data.Models;

namespace Data.Collections
{
    internal class UserCollection : ILibraryCollection<IUser>
    {
        private IDatabase Database;

        public UserCollection()
        {
            Database = MockedDatabase.Instance;
        }

        public UserCollection(IDatabase database)
        {
            Database = database;
        }

        public IUser Add(IUser entity)
        {
            if (Database.Users.Find(c => c.Name.Equals(entity.Name)) == null)
            {
                Database.Users.Add(entity);
                return entity;
            }

            return null;
        }

        public void Delete(int id)
        {
            IUser user = Database.Users.Find(c => c.ID == id);

            if (user != null)
                Database.Users.Remove(user);
        }

        public IEnumerable<IUser> Get(Predicate<IUser> pred)
        {
            return Database.Users.FindAll(pred);
        }

        public IUser Get(int id)
        {
            return Database.Users.Find(c => c.ID == id);
        }

        public IEnumerable<IUser> Get()
        {
            return Database.Users;
        }

        public IUser Update(IUser entity)
        {
            IUser IUser = Database.Users.Find(c => c.ID == entity.ID);

            if (IUser != null)
            {
                IUser.Name = entity.Name;
                IUser.Address = entity.Address;
            }

            return IUser;
        }
    }
}
