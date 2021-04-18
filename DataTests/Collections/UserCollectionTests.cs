using Microsoft.VisualStudio.TestTools.UnitTesting;
using Data.Collections;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using Data.Models;
using DataTests;

namespace Data.Collections.Tests
{
    [TestClass()]
    public class UserCollectionTests
    {
        [TestMethod()]
        public void AddTest()
        {
            ILibraryCollection<User> UserCollection = new UserCollection(new TestDatabase());
            UserCollection.Add(new User { Name = "User1", Address = "User1Address" });
            Assert.IsNotNull(UserCollection.Get((u => u.Name == "User1")));
        }

        [TestMethod()]
        public void DeleteTest()
        {
            ILibraryCollection<User> UserCollection = new UserCollection(new TestDatabase());
            User u = new User { Name = "User1", Address = "User1Address" };
            UserCollection.Add(u);
            UserCollection.Delete(u.ID);
            Assert.AreEqual(0, UserCollection.Get().ToList().Count());
        }

        [TestMethod()]
        public void GetTest()
        {
            ILibraryCollection<User> UserCollection = new UserCollection(new TestDatabase());
            User u1 = new User { Name = "User1", Address = "User1Address" };
            User u2 = new User { Name = "User2", Address = "User2Address" };
            UserCollection.Add(u1);
            UserCollection.Add(u2);
            Assert.AreEqual(1, UserCollection.Get((u => u.Name == "User2")).ToList().Count);
        }

        [TestMethod()]
        public void GetTest1()
        {
            ILibraryCollection<User> UserCollection = new UserCollection(new TestDatabase());
            User u1 = new User { Name = "User1", Address = "User1Address" };
            UserCollection.Add(u1);
            Assert.IsNotNull(UserCollection.Get(u1.ID));
        }

        [TestMethod()]
        public void GetTest2()
        {
            ILibraryCollection<User> UserCollection = new UserCollection(new TestDatabase());
            User u1 = new User { Name = "User1", Address = "User1Address" };
            UserCollection.Add(u1);
            Assert.IsNotNull(UserCollection.Get());
        }

        [TestMethod()]
        public void UpdateTest()
        {
            ILibraryCollection<User> UserCollection = new UserCollection(new TestDatabase());
            User u1 = new User { Name = "User1", Address = "User1Address" };
            User u2 = new User { Name = "User1", Address = "User2Address" };
            UserCollection.Add(u1);
            u2.ID = u1.ID;
            Assert.AreEqual(u2.Address, UserCollection.Update(u2).Address);
        }
    }
}