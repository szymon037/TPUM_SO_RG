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
            ILibraryCollection<IOrder> OrderCollection = Factory.CreateOrderCollection(new DataTestDatabase());
            OrderCollection.Add(Factory.CreateOrder(1, 1, false));

            Assert.IsNotNull(OrderCollection.Get((o => o.UserID == 1)));
        }

        [TestMethod()]
        public void DeleteTest()
        {
            ILibraryCollection<IOrder> OrderCollection = Factory.CreateOrderCollection(new DataTestDatabase());
            IOrder o = OrderCollection.Add(Factory.CreateOrder(1, 1, false));
            OrderCollection.Delete(o.ID);

            Assert.AreEqual(0, OrderCollection.Get().ToList().Count());
        }

        [TestMethod()]
        public void GetTest()
        {
            ILibraryCollection<IOrder> OrderCollection = Factory.CreateOrderCollection(new DataTestDatabase());
            IOrder o1 = OrderCollection.Add(Factory.CreateOrder(1, 1, false));
            IOrder o2 = OrderCollection.Add(Factory.CreateOrder(1, 2, false));

            Assert.AreEqual(2, OrderCollection.Get((o => o.UserID == 1)).ToList().Count);
        }

        [TestMethod()]
        public void GetTest1()
        {
            ILibraryCollection<IOrder> OrderCollection = Factory.CreateOrderCollection(new DataTestDatabase());
            IOrder o1 = OrderCollection.Add(Factory.CreateOrder(1, 1, false));

            Assert.IsNotNull(OrderCollection.Get(o1.ID));
        }

        [TestMethod()]
        public void GetTest2()
        {
            ILibraryCollection<IOrder> OrderCollection = Factory.CreateOrderCollection(new DataTestDatabase());
            OrderCollection.Add(Factory.CreateOrder(1, 1, false));

            Assert.AreEqual(1, OrderCollection.Get().Count());
        }

        [TestMethod()]
        public void UpdateTest()
        {
            ILibraryCollection<IOrder> OrderCollection = Factory.CreateOrderCollection(new DataTestDatabase());
            IOrder o1 = OrderCollection.Add(Factory.CreateOrder(1, 1, false));
            IOrder o2 = OrderCollection.Add(Factory.CreateOrder(1, 2, false));

            o2.ID = o1.ID;
            Assert.AreEqual(o2.BookID, OrderCollection.Update(o2).BookID);
        }
    }
}