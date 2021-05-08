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
            ILibraryCollection<IUser> UserCollection = Factory.CreateUserCollection(new DataTestDatabase());
            UserCollection.Add(Factory.CreateUser("User1", "User1Address"));

            Assert.IsNotNull(UserCollection.Get((u => u.Name == "User1")));
        }

        [TestMethod()]
        public void DeleteTest()
        {
            ILibraryCollection<IUser> UserCollection = Factory.CreateUserCollection(new DataTestDatabase());
            IUser u = UserCollection.Add(Factory.CreateUser("User1", "User1Address"));
            UserCollection.Delete(u.ID);

            Assert.AreEqual(0, UserCollection.Get().ToList().Count());
        }

        [TestMethod()]
        public void GetTest()
        {
            ILibraryCollection<IUser> UserCollection = Factory.CreateUserCollection(new DataTestDatabase());
            UserCollection.Add(Factory.CreateUser("User1", "User1Address"));
            UserCollection.Add(Factory.CreateUser("User2", "User2Address"));

            Assert.AreEqual(1, UserCollection.Get((u => u.Name == "User2")).ToList().Count);
        }

        [TestMethod()]
        public void GetTest1()
        {
            ILibraryCollection<IUser> UserCollection = Factory.CreateUserCollection(new DataTestDatabase());
            IUser u = UserCollection.Add(Factory.CreateUser("User1", "User1Address"));

            Assert.IsNotNull(UserCollection.Get(u.ID));
        }

        [TestMethod()]
        public void GetTest2()
        {
            ILibraryCollection<IUser> UserCollection = Factory.CreateUserCollection(new DataTestDatabase());
            UserCollection.Add(Factory.CreateUser("User1", "User1Address"));

            Assert.AreEqual(1, UserCollection.Get().Count());
        }

        [TestMethod()]
        public void UpdateTest()
        {
            ILibraryCollection<IUser> UserCollection = Factory.CreateUserCollection(new DataTestDatabase());
            IUser u1 = UserCollection.Add(Factory.CreateUser("User1", "User1Address"));
            IUser u2 = UserCollection.Add(Factory.CreateUser("User2", "User2Address"));
            u2.ID = u1.ID;

            Assert.AreEqual(u2.Address, UserCollection.Update(u2).Address);
        }
    }
}