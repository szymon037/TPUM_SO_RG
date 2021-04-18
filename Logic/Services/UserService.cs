
using System.Collections.Generic;
using System.Linq;

using Data.Collections;
using Data.Models;
using Logic.DataDTO;

namespace Logic.Services
{
    internal class UserService
    {
        private ILibraryCollection<User> UserCollection;

        public UserService()
        {
            UserCollection = new UserCollection();
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
