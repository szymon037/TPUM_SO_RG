using Microsoft.VisualStudio.TestTools.UnitTesting;
using Logic.Systems;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using Logic.DataDTO;
using LogicTests;
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
            boCol.Add(new Book { Title = "Title1", Author = "Author1" });
            var book = boCol.Add(new Book { Title = "Title2", Author = "Author2" });

            var orCol = new ImpOrderColletion();
            var order = orCol.Add(new Order { UserID = 1, BookID = book.ID, Returned = false });

            IOrderSystem OrderSystem = new OrderSystem(boCol, orCol);

            Assert.IsNotNull(OrderSystem.GetOrder(order.ID));
        }
        
        [TestMethod()]
        public void GetOrdersTest()
        {
            var boCol = new ImpBookColletion();
            boCol.Add(new Book { Title = "Title1", Author = "Author1" });
            var book = boCol.Add(new Book { Title = "Title2", Author = "Author2" });

            var orCol = new ImpOrderColletion();
            orCol.Add(new Order { UserID = 1, BookID = book.ID, Returned = true });
            orCol.Add(new Order { UserID = 2, BookID = book.ID, Returned = false });

            IOrderSystem OrderSystem = new OrderSystem(boCol, orCol);

            Assert.AreEqual(2, OrderSystem.GetOrders().Count());
        }

        [TestMethod()]
        public void GetUserOrdersTest()
        {
            var boCol = new ImpBookColletion();
            var book1 = boCol.Add(new Book { Title = "Title1", Author = "Author1" });
            var book2 = boCol.Add(new Book { Title = "Title2", Author = "Author2" });

            var orCol = new ImpOrderColletion();
            orCol.Add(new Order { UserID = 1, BookID = book1.ID, Returned = true });
            orCol.Add(new Order { UserID = 1, BookID = book2.ID, Returned = false });
            orCol.Add(new Order { UserID = 2, BookID = book1.ID, Returned = false });

            IOrderSystem OrderSystem = new OrderSystem(boCol, orCol);

            Assert.AreEqual(2, OrderSystem.GetUserOrders(1).Count());
        }

        [TestMethod()]
        public void GetUnfinishedOrdersTest()
        {
            var boCol = new ImpBookColletion();
            var book1 = boCol.Add(new Book { Title = "Title1", Author = "Author1" });
            var book2 = boCol.Add(new Book { Title = "Title2", Author = "Author2" });

            var orCol = new ImpOrderColletion();
            orCol.Add(new Order { UserID = 1, BookID = book1.ID, Returned = true });
            orCol.Add(new Order { UserID = 1, BookID = book2.ID, Returned = false });
            orCol.Add(new Order { UserID = 2, BookID = book1.ID, Returned = false });

            IOrderSystem OrderSystem = new OrderSystem(boCol, orCol);

            Assert.AreEqual(2, OrderSystem.GetUnfinishedOrders().Count());
        }
        
        [TestMethod()]
        public void ReturnBookTest()
        {
            var boCol = new ImpBookColletion();
            var book1 = boCol.Add(new Book { Title = "Title1", Author = "Author1" });
            var book2 = boCol.Add(new Book { Title = "Title2", Author = "Author2" });

            var orCol = new ImpOrderColletion();
            orCol.Add(new Order { UserID = 1, BookID = book1.ID, Returned = true });
            var order = orCol.Add(new Order { UserID = 1, BookID = book2.ID, Returned = false });
            orCol.Add(new Order { UserID = 2, BookID = book1.ID, Returned = false });

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
            var book1 = boCol.Add(new Book { Title = "Title1", Author = "Author1" });
            var book2 = boCol.Add(new Book { Title = "Title2", Author = "Author2" });

            var orCol = new ImpOrderColletion();
            orCol.Add(new Order { UserID = 1, BookID = book1.ID, Returned = true });
            orCol.Add(new Order { UserID = 2, BookID = book1.ID, Returned = false });

            BookDTO b1 = new BookDTO() { ID = book2.ID, Title = "Title1", Author = "Author1" };
            UserDTO u1 = new UserDTO() { ID = 1, Name = "User1", Address = "Address1" };

            IOrderSystem OrderSystem = new OrderSystem(boCol, orCol);
            Assert.IsNotNull(OrderSystem.BorrowBook(b1, u1));
        }
    }
}