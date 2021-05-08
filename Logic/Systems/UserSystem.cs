
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
        private ILibraryCollection<IUser> UserCollection;

        public UserSystem()
        {
            UserCollection = Factory.CreateUserCollection();
        }

        public UserSystem(ILibraryCollection<IUser> uC)
        {
            UserCollection = uC;
        }

        public UserDTO AddUser(UserDTO user)
        {
            IUser newUser = Factory.CreateUser(user.Name, user.Address);

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
            IEnumerable<IUser> users = UserCollection.Get();

            return users.Select(c => Translator.TranslateUser(c)).ToList();
        }
    }
}
