﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
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
    public class BookSystemTests
    {
        [TestMethod()]
        public void AddBookTest()
        {
            IBookSystem BookSystem = new BookSystem(new LogicTestDatabse());
            BookDTO b = new BookDTO() { Title = "Title1", Author = "Author1"};
            b = BookSystem.AddBook(b);
            Assert.AreEqual(b.Title, BookSystem.GetBook(b.ID).Title);
        }

        [TestMethod()]
        public void GetBookTest()
        {
            IBookSystem BookSystem = new BookSystem(new LogicTestDatabse());
            BookDTO b = new BookDTO() { Title = "Title1", Author = "Author1" };
            b = BookSystem.AddBook(b);
            Assert.IsNotNull(BookSystem.GetBook(b.ID));
        }

        [TestMethod()]
        public void GetNumberOfBooksTest()
        {
            IBookSystem BookSystem = new BookSystem(new LogicTestDatabse());
            BookDTO b = new BookDTO() { Title = "Title1", Author = "Author1" };
            BookSystem.AddBook(b);
            Assert.AreEqual(1, BookSystem.GetNumberOfBooks());
        }

        [TestMethod()]
        public void GetBooksTest()
        {
            IBookSystem BookSystem = new BookSystem(new LogicTestDatabse());
            BookDTO b = new BookDTO() { Title = "Title1", Author = "Author1" };
            BookSystem.AddBook(b);
            Assert.IsNotNull(BookSystem.GetBooks());
        }

        [TestMethod()]
        public void GetBooksByAuthorTest()
        {
            IBookSystem BookSystem = new BookSystem(new LogicTestDatabse());
            BookDTO b = new BookDTO() { Title = "Title1", Author = "Author1" };
            BookSystem.AddBook(b);
            Assert.IsNotNull(BookSystem.GetBooksByAuthor("Author1"));
        }

        [TestMethod()]
        public void GetAvailableBooksTest()
        {
            LogicTestDatabse logicTestDatabse = new LogicTestDatabse();
            IBookSystem BookSystem = new BookSystem(logicTestDatabse);
            IOrderSystem OrderSystem = new OrderSystem(logicTestDatabse);

            BookDTO b1 = new BookDTO() { Title = "Title1", Author = "Author1" };
            BookDTO b2 = new BookDTO() { Title = "Title2", Author = "Author2" };
            UserDTO u1 = new UserDTO() { Name = "User1", Address = "Address1" };

            b1 = BookSystem.AddBook(b1);
            b2 = BookSystem.AddBook(b2);
            OrderSystem.BorrowBook(b1, u1);

            Assert.AreEqual(1, BookSystem.GetAvailableBooks().ToList().Count);
        }
    }
}