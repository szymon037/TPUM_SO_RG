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
    public class OrderCollectionTests
    {
        [TestMethod()]
        public void AddTest()
        {
            ILibraryCollection<Order> OrderCollection = new OrderCollection(new TestDatabase());
            OrderCollection.Add(new Order { UserID = 1, BookID = 1 });
            Assert.IsNotNull(OrderCollection.Get((o => o.UserID == 1)));
        }

        [TestMethod()]
        public void DeleteTest()
        {
            ILibraryCollection<Order> OrderCollection = new OrderCollection(new TestDatabase());
            Order o = new Order { UserID = 1, BookID = 1 };
            OrderCollection.Add(o);
            OrderCollection.Delete(o.ID);
            Assert.AreEqual(0, OrderCollection.Get().ToList().Count());
        }

        [TestMethod()]
        public void GetTest()
        {
            ILibraryCollection<Order> OrderCollection = new OrderCollection(new TestDatabase());
            Order o1 = new Order { UserID = 1, BookID = 1 };
            Order o2 = new Order { UserID = 1, BookID = 2 };
            OrderCollection.Add(o1);
            OrderCollection.Add(o2);
            Assert.AreEqual(2, OrderCollection.Get((o => o.UserID == 1)).ToList().Count);
        }

        [TestMethod()]
        public void GetTest1()
        {
            ILibraryCollection<Order> OrderCollection = new OrderCollection(new TestDatabase());
            Order o1 = new Order { UserID = 1, BookID = 1 };
            OrderCollection.Add(o1);
            Assert.IsNotNull(OrderCollection.Get(o1.ID));
        }

        [TestMethod()]
        public void GetTest2()
        {
            ILibraryCollection<Order> OrderCollection = new OrderCollection(new TestDatabase());
            Order b1 = new Order { UserID = 1, BookID = 1 };
            OrderCollection.Add(b1);
            Assert.IsNotNull(OrderCollection.Get());
        }

        [TestMethod()]
        public void UpdateTest()
        {
            ILibraryCollection<Order> OrderCollection = new OrderCollection(new TestDatabase());
            Order o1 = new Order { UserID = 1, BookID = 1 };
            Order o2 = new Order { UserID = 1, BookID = 2 };
            OrderCollection.Add(o1);
            o2.ID = o1.ID;
            Assert.AreEqual(o2.BookID, OrderCollection.Update(o2).BookID);
        }
    }
}