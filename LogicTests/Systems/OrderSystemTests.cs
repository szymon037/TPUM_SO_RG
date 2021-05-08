using Microsoft.VisualStudio.TestTools.UnitTesting;
using Logic.Systems;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

using Logic.DataDTO;
using LogicTests;

using Data;
using Data.Models;

namespace Logic.Systems.Tests
{
    [TestClass()]
    public class OrderSystemTests
    {
        [TestMethod()]
        public void GetOrderTest()
        {
            var boCol = new ImpBookColletion();
            boCol.Add(Factory.CreateBook("Title1", "Author1", DateTime.Now));
            var book = boCol.Add(Factory.CreateBook("Title2", "Author2", DateTime.Now));

            var orCol = new ImpOrderColletion();
            var order = orCol.Add(Factory.CreateOrder(1, book.ID, false));

            IOrderSystem OrderSystem = new OrderSystem(boCol, orCol);

            Assert.IsNotNull(OrderSystem.GetOrder(order.ID));
        }
        
        [TestMethod()]
        public void GetOrdersTest()
        {
            var boCol = new ImpBookColletion();
            boCol.Add(Factory.CreateBook("Title1", "Author1", DateTime.Now));
            var book = boCol.Add(Factory.CreateBook("Title2", "Author2", DateTime.Now));

            var orCol = new ImpOrderColletion();
            orCol.Add(Factory.CreateOrder(1, book.ID, true));
            orCol.Add(Factory.CreateOrder(2, book.ID, false));

            IOrderSystem OrderSystem = new OrderSystem(boCol, orCol);

            Assert.AreEqual(2, OrderSystem.GetOrders().Count());
        }

        [TestMethod()]
        public void GetUserOrdersTest()
        {
            var boCol = new ImpBookColletion();
            var book1 = boCol.Add(Factory.CreateBook("Title1", "Author1", DateTime.Now));
            var book2 = boCol.Add(Factory.CreateBook("Title2", "Author2", DateTime.Now));

            var orCol = new ImpOrderColletion();
            orCol.Add(Factory.CreateOrder(1, book1.ID, true));
            orCol.Add(Factory.CreateOrder(1, book2.ID, false));
            orCol.Add(Factory.CreateOrder(2, book1.ID, false));

            IOrderSystem OrderSystem = new OrderSystem(boCol, orCol);

            Assert.AreEqual(2, OrderSystem.GetUserOrders(1).Count());
        }

        [TestMethod()]
        public void GetUnfinishedOrdersTest()
        {
            var boCol = new ImpBookColletion();
            var book1 = boCol.Add(Factory.CreateBook("Title1", "Author1", DateTime.Now));
            var book2 = boCol.Add(Factory.CreateBook("Title2", "Author2", DateTime.Now));

            var orCol = new ImpOrderColletion();
            orCol.Add(Factory.CreateOrder(1, book1.ID, true));
            orCol.Add(Factory.CreateOrder(1, book2.ID, false));
            orCol.Add(Factory.CreateOrder(2, book1.ID, false));

            IOrderSystem OrderSystem = new OrderSystem(boCol, orCol);

            Assert.AreEqual(2, OrderSystem.GetUnfinishedOrders().Count());
        }
        
        [TestMethod()]
        public void ReturnBookTest()
        {
            var boCol = new ImpBookColletion();
            var book1 = boCol.Add(Factory.CreateBook("Title1", "Author1", DateTime.Now));
            var book2 = boCol.Add(Factory.CreateBook("Title2", "Author2", DateTime.Now));

            var orCol = new ImpOrderColletion();
            orCol.Add(Factory.CreateOrder(1, book1.ID, true));
            IOrder order = orCol.Add(Factory.CreateOrder(1, book2.ID, false));
            orCol.Add(Factory.CreateOrder(2, book1.ID, false));

            IOrderSystem OrderSystem = new OrderSystem(boCol, orCol);
            var o = OrderSystem.GetOrder(order.ID);

            Assert.IsFalse(o.Returned);
            Assert.IsNotNull(OrderSystem.ReturnBook(o));
            Assert.IsTrue(o.Returned);
        }
        
        [TestMethod()]
        public void BorrowBookTest()
        {
            var boCol = new ImpBookColletion();
            var book1 = boCol.Add(Factory.CreateBook("Title1", "Author1", DateTime.Now));
            var book2 = boCol.Add(Factory.CreateBook("Title2", "Author2", DateTime.Now));

            var orCol = new ImpOrderColletion();
            orCol.Add(Factory.CreateOrder(1, book1.ID, true));
            orCol.Add(Factory.CreateOrder(2, book1.ID, false));

            BookDTO b1 = new BookDTO() { ID = book2.ID, Title = "Title1", Author = "Author1" };
            UserDTO u1 = new UserDTO() { ID = 1, Name = "User1", Address = "Address1" };

            IOrderSystem OrderSystem = new OrderSystem(boCol, orCol);
            Assert.IsNotNull(OrderSystem.BorrowBook(b1, u1));
        }
    }
}