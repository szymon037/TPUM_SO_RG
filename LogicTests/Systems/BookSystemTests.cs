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
            var book = boCol.Add(new Book { Title = "Title1", Author = "Author1" });
            boCol.Add(new Book { Title = "Title2", Author = "Author2" });

            IBookSystem BookSystem = new BookSystem(boCol, new ImpOrderColletion());

            Assert.IsNotNull(BookSystem.GetBook(book.ID));
        }

        [TestMethod()]
        public void GetNumberOfBooksTest()
        {
            var boCol = new ImpBookColletion();
            boCol.Add(new Book { Title = "Title1", Author = "Author1" });
            boCol.Add(new Book { Title = "Title2", Author = "Author2" });

            IBookSystem BookSystem = new BookSystem(boCol, new ImpOrderColletion());

            Assert.AreEqual(2, BookSystem.GetNumberOfBooks());
        }

        [TestMethod()]
        public void GetBooksTest()
        {
            var boCol = new ImpBookColletion();
            boCol.Add(new Book { Title = "Title1", Author = "Author1" });
            boCol.Add(new Book { Title = "Title2", Author = "Author2" });

            IBookSystem BookSystem = new BookSystem(boCol, new ImpOrderColletion());

            Assert.AreEqual(2, BookSystem.GetBooks().Count());
        }

        [TestMethod()]
        public void GetBooksByAuthorTest()
        {
            var boCol = new ImpBookColletion();
            boCol.Add(new Book { Title = "Title1", Author = "Author1" });
            boCol.Add(new Book { Title = "Title2", Author = "Author2" });
            boCol.Add(new Book { Title = "Title3", Author = "Author1" });

            IBookSystem BookSystem = new BookSystem(boCol, new ImpOrderColletion());

            Assert.AreEqual(2, BookSystem.GetBooksByAuthor("Author1").Count());
        }

        [TestMethod()]
        public void GetAvailableBooksTest()
        {
            var boCol = new ImpBookColletion();
            boCol.Add(new Book { Title = "Title1", Author = "Author1" });
            var book = boCol.Add(new Book { Title = "Title2", Author = "Author2" });

            var orCol = new ImpOrderColletion();
            orCol.Add(new Order { UserID = 1, BookID = book.ID, Returned = false });

            IBookSystem BookSystem = new BookSystem(boCol, orCol);

            Assert.AreEqual(1, BookSystem.GetAvailableBooks().ToList().Count);
        }
    }
}