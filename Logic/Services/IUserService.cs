using System;
using System.Collections.Generic;
using System.Text;

using Logic.DataDTO;

namespace Logic.Services
{
    public interface IUserService
    {
        public UserDTO AddUser(UserDTO user);
        public UserDTO GetUser(int id);
        public IEnumerable<UserDTO> GetUsers();
    }
}
