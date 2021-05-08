using Microsoft.VisualStudio.TestTools.UnitTesting;
using Logic.Systems;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using Logic.DataDTO;
using LogicTests;
using Data.Models;
using Data;

namespace Logic.Systems.Tests
{
    [TestClass()]
    public class BookSystemTests
    {
        [TestMethod()]
        public void AddBookTest()
        {
            IBookSystem BookSystem = new BookSystem(new ImpBookColletion(), new ImpOrderColletion());
            BookDTO b = new BookDTO() { Title = "Title1", Author = "Author1"};
            b = BookSystem.AddBook(b);
            Assert.AreEqual(b.Title, BookSystem.GetBook(b.ID).Title);
        }

        [TestMethod()]
        public void GetBookTest()
        {
            var boCol = new ImpBookColletion();
            var book = boCol.Add(Factory.CreateBook("Title1", "Author1", DateTime.Now));
            boCol.Add(Factory.CreateBook("Title2", "Author2", DateTime.Now));

            IBookSystem BookSystem = new BookSystem(boCol, new ImpOrderColletion());

            Assert.IsNotNull(BookSystem.GetBook(book.ID));
        }

        [TestMethod()]
        public void GetNumberOfBooksTest()
        {
            var boCol = new ImpBookColletion();
            boCol.Add(Factory.CreateBook("Title1", "Author1", DateTime.Now));
            boCol.Add(Factory.CreateBook("Title2", "Author2", DateTime.Now));

            IBookSystem BookSystem = new BookSystem(boCol, new ImpOrderColletion());

            Assert.AreEqual(2, BookSystem.GetNumberOfBooks());
        }

        [TestMethod()]
        public void GetBooksTest()
        {
            var boCol = new ImpBookColletion();
            boCol.Add(Factory.CreateBook("Title1", "Author1", DateTime.Now));
            boCol.Add(Factory.CreateBook("Title2", "Author2", DateTime.Now));

            IBookSystem BookSystem = new BookSystem(boCol, new ImpOrderColletion());

            Assert.AreEqual(2, BookSystem.GetBooks().Count());
        }

        [TestMethod()]
        public void GetBooksByAuthorTest()
        {
            var boCol = new ImpBookColletion();
            boCol.Add(Factory.CreateBook("Title1", "Author1", DateTime.Now));
            boCol.Add(Factory.CreateBook("Title2", "Author2", DateTime.Now));
            boCol.Add(Factory.CreateBook("Title3", "Author1", DateTime.Now));

            IBookSystem BookSystem = new BookSystem(boCol, new ImpOrderColletion());

            Assert.AreEqual(2, BookSystem.GetBooksByAuthor("Author1").Count());
        }

        [TestMethod()]
        public void GetAvailableBooksTest()
        {
            var boCol = new ImpBookColletion();
            boCol.Add(Factory.CreateBook("Title1", "Author1", DateTime.Now));
            var book = boCol.Add(Factory.CreateBook("Title2", "Author2", DateTime.Now));

            var orCol = new ImpOrderColletion();
            orCol.Add(Factory.CreateOrder(1, book.ID, false));
            
            IBookSystem BookSystem = new BookSystem(boCol, orCol);

            Assert.AreEqual(1, BookSystem.GetAvailableBooks().ToList().Count);
        }
    }
}