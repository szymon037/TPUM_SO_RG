using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

using Logic.DataDTO;
using LogicTests;
using Data.Models;

namespace Logic.Systems.Tests
{
    [TestClass()]
    public class UserSystemTests
    {
        [TestMethod()]
        public void AddUserTest()
        {
            IUserSystem UserSystem = new UserSystem(new ImpUserCollection());
            UserDTO b = new UserDTO() { Name = "User1", Address = "Address1" };

            Assert.AreEqual(0, UserSystem.GetUsers().Count());

            b = UserSystem.AddUser(b);

            Assert.IsNotNull(UserSystem.GetUser(b.ID));
            Assert.AreEqual(1, UserSystem.GetUsers().Count());
        }

        [TestMethod()]
        public void GetUserTest()
        {
            var usCol = new ImpUserCollection();
            var user = usCol.Add(new User { Name = "Name1", Address = "Address1" });
            usCol.Add(new User { Name = "Name2", Address = "Address2" });

            IUserSystem UserSystem = new UserSystem(usCol);

            Assert.IsNotNull(UserSystem.GetUser(user.ID));
        }

        [TestMethod()]
        public void GetUsersTest()
        {
            var usCol = new ImpUserCollection();
            usCol.Add(new User { Name = "Name1", Address = "Address1" });
            usCol.Add(new User { Name = "Name2", Address = "Address2" });

            IUserSystem UserSystem = new UserSystem(usCol);

            Assert.AreEqual(2, UserSystem.GetUsers().Count());
        }
    }
}