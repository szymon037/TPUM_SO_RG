using System;
using System.Collections.Generic;
using System.Text;

using Model.Data;

namespace Model.Repository
{
    public class UserCollection : IBaseCollection<User>
    {
        public List<User> Users { get; set; }

        public UserCollection()
        {
            Users = new Database().Users;
        }

        public User Add(User entity)
        {
            if (Users.Find(c => c.ID == entity.ID) == null)
            {
                Users.Add(entity);
            }

            return entity;
        }

        public void Delete(int id)
        {
            User user = Users.Find(c => c.ID == id);

            if (user != null)
                Users.Remove(user);
        }

        public IEnumerable<User> Get(Predicate<User> pred)
        {
            return Users.FindAll(pred);
        }

        public User Get(int id)
        {
            return Users.Find(c => c.ID == id);
        }

        public User Update(int id, User entity)
        {
            User user = Users.Find(c => c.ID == id);

            if (user != null)
            {
                user.Name = entity.Name;
                user.Address = entity.Address;
            }

            return user;
        }
    }
}
