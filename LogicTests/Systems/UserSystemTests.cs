using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

using Logic.DataDTO;
using LogicTests;

namespace Logic.Systems.Tests
{
    [TestClass()]
    public class UserSystemTests
    {
        [TestMethod()]
        public void AddUserTest()
        {
            IUserSystem UserSystem = new UserSystem(new LogicTestDatabse());
            UserDTO b = new UserDTO() { Name = "User1", Address = "Address1" };

            Assert.AreEqual(0, UserSystem.GetUsers().Count());

            b = UserSystem.AddUser(b);

            Assert.IsNotNull(UserSystem.GetUser(b.ID));
            Assert.AreEqual(1, UserSystem.GetUsers().Count());
        }

        [TestMethod()]
        public void GetUserTest()
        {
            IUserSystem UserSystem = new UserSystem(new LogicTestDatabse());
            UserDTO b = new UserDTO() { Name = "User1", Address = "Address1" };
            b = UserSystem.AddUser(b);
            Assert.IsNotNull(UserSystem.GetUser(b.ID));
        }

        [TestMethod()]
        public void GetUsersTest()
        {
            IUserSystem UserSystem = new UserSystem(new LogicTestDatabse());

            UserDTO b = new UserDTO() { Name = "User1", Address = "Address1" };
            UserSystem.AddUser(b);

            b = new UserDTO() { Name = "User2", Address = "Address2" };
            UserSystem.AddUser(b);

            Assert.AreEqual(2, UserSystem.GetUsers().Count());
        }
    }
}