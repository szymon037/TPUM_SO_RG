
using System.Collections.Generic;
using System.Linq;

using Data.Collections;
using Data.Models;
using Data;
using Logic.DataDTO;

namespace Logic.Systems
{
    public class UserSystem : IUserSystem
    {
        private ILibraryCollection<User> UserCollection;

        public UserSystem()
        {
            UserCollection = new UserCollection();
        }

        public UserSystem(IDatabase database)
        {
            UserCollection = new UserCollection(database);
        }

        public UserDTO AddUser(UserDTO user)
        {
            User newUser = new User
            {
                Name = user.Name,
                Address = user.Address
            };

            var res = UserCollection.Add(newUser);
            if (res is null) return null;
            else return Translator.TranslateUser(res);
        }

        public UserDTO GetUser(int id)
        {
            return Translator.TranslateUser(UserCollection.Get(id));
        }

        public IEnumerable<UserDTO> GetUsers()
        {
            IEnumerable<User> users = UserCollection.Get();

            return users.Select(c => Translator.TranslateUser(c)).ToList();
        }
    }
}
