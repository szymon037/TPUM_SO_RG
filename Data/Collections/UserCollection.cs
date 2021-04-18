using System;
using System.Collections.Generic;

using Data;
using Data.Models;

namespace Data.Collections
{
    public class UserCollection : ILibraryCollection<User>
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

        public User Add(User entity)
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
            User user = Database.Users.Find(c => c.ID == id);

            if (user != null)
                Database.Users.Remove(user);
        }

        public IEnumerable<User> Get(Predicate<User> pred)
        {
            return Database.Users.FindAll(pred);
        }

        public User Get(int id)
        {
            return Database.Users.Find(c => c.ID == id);
        }

        public IEnumerable<User> Get()
        {
            return Database.Users;
        }

        public User Update(int id, User entity)
        {
            User user = Database.Users.Find(c => c.ID == id);

            if (user != null)
            {
                user.Name = entity.Name;
                user.Address = entity.Address;
            }

            return user;
        }
    }
}
