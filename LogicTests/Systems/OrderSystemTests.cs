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
            LogicTestDatabse logicTestDatabse = new LogicTestDatabse();
            IBookSystem BookSystem = new BookSystem(logicTestDatabse);
            IOrderSystem OrderSystem = new OrderSystem(logicTestDatabse);
            IUserSystem UserSystem = new UserSystem(logicTestDatabse);

            BookDTO b1 = new BookDTO() { Title = "Title1", Author = "Author1" };
            UserDTO u1 = new UserDTO() { Name = "User1", Address = "Address1" };

            b1 = BookSystem.AddBook(b1);
            u1 = UserSystem.AddUser(u1);

            OrderDTO o = OrderSystem.BorrowBook(b1, u1);
            Assert.IsNotNull(OrderSystem.GetOrder(o.ID));
        }

        [TestMethod()]
        public void GetOrdersTest()
        {
            LogicTestDatabse logicTestDatabse = new LogicTestDatabse();
            IBookSystem BookSystem = new BookSystem(logicTestDatabse);
            IOrderSystem OrderSystem = new OrderSystem(logicTestDatabse);
            IUserSystem UserSystem = new UserSystem(logicTestDatabse);

            BookDTO b1 = new BookDTO() { Title = "Title1", Author = "Author1" };
            UserDTO u1 = new UserDTO() { Name = "User1", Address = "Address1" };

            b1 = BookSystem.AddBook(b1);
            u1 = UserSystem.AddUser(u1);

            OrderDTO o = OrderSystem.BorrowBook(b1, u1);
            Assert.IsNotNull(OrderSystem.GetOrders());
        }

        [TestMethod()]
        public void GetUserOrdersTest()
        {
            LogicTestDatabse logicTestDatabse = new LogicTestDatabse();
            IBookSystem BookSystem = new BookSystem(logicTestDatabse);
            IOrderSystem OrderSystem = new OrderSystem(logicTestDatabse);
            IUserSystem UserSystem = new UserSystem(logicTestDatabse);

            BookDTO b1 = new BookDTO() { Title = "Title1", Author = "Author1" };
            UserDTO u1 = new UserDTO() { Name = "User1", Address = "Address1" };

            b1 = BookSystem.AddBook(b1);
            u1 = UserSystem.AddUser(u1);

            OrderDTO o = OrderSystem.BorrowBook(b1, u1);
            Assert.IsNotNull(OrderSystem.GetUserOrders(u1.ID));
        }

        [TestMethod()]
        public void GetUnfinishedOrdersTest()
        {
            LogicTestDatabse logicTestDatabse = new LogicTestDatabse();
            IBookSystem BookSystem = new BookSystem(logicTestDatabse);
            IOrderSystem OrderSystem = new OrderSystem(logicTestDatabse);
            IUserSystem UserSystem = new UserSystem(logicTestDatabse);

            BookDTO b1 = new BookDTO() { Title = "Title1", Author = "Author1" };
            UserDTO u1 = new UserDTO() { Name = "User1", Address = "Address1" };

            b1 = BookSystem.AddBook(b1);
            u1 = UserSystem.AddUser(u1);

            OrderDTO o = OrderSystem.BorrowBook(b1, u1);
            Assert.AreEqual(1, OrderSystem.GetUnfinishedOrders().ToList().Count);
        }

        [TestMethod()]
        public void ReturnBookTest()
        {
            LogicTestDatabse logicTestDatabse = new LogicTestDatabse();
            IBookSystem BookSystem = new BookSystem(logicTestDatabse);
            IOrderSystem OrderSystem = new OrderSystem(logicTestDatabse);
            IUserSystem UserSystem = new UserSystem(logicTestDatabse);

            BookDTO b1 = new BookDTO() { Title = "Title1", Author = "Author1" };
            UserDTO u1 = new UserDTO() { Name = "User1", Address = "Address1" };

            b1 = BookSystem.AddBook(b1);
            u1 = UserSystem.AddUser(u1);

            OrderDTO o = OrderSystem.BorrowBook(b1, u1);
            Assert.IsNotNull(OrderSystem.ReturnBook(o));
        }

        [TestMethod()]
        public void BorrowBookTest()
        {
            LogicTestDatabse logicTestDatabse = new LogicTestDatabse();
            IBookSystem BookSystem = new BookSystem(logicTestDatabse);
            IOrderSystem OrderSystem = new OrderSystem(logicTestDatabse);
            IUserSystem UserSystem = new UserSystem(logicTestDatabse);

            BookDTO b1 = new BookDTO() { Title = "Title1", Author = "Author1" };
            UserDTO u1 = new UserDTO() { Name = "User1", Address = "Address1" };

            b1 = BookSystem.AddBook(b1);
            u1 = UserSystem.AddUser(u1);

            OrderDTO o = OrderSystem.BorrowBook(b1, u1);
            Assert.AreEqual(1, OrderSystem.GetOrders().ToList().Count);
        }
    }
}