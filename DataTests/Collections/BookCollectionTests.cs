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
    public class BookCollectionTests
    {
        [TestMethod()]
        public void AddTest()
        {
            ILibraryCollection<Book> BookCollection = new BookCollection(new TestDatabase());
            BookCollection.Add(new Book { Title = "Book1", Author = "Author1" });
            Assert.IsNotNull(BookCollection.Get((b => b.Title == "Book1")));
        }

        [TestMethod()]
        public void DeleteTest()
        {
            ILibraryCollection<Book> BookCollection = new BookCollection(new TestDatabase());
            Book b = new Book { Title = "Book1", Author = "Author1" };
            BookCollection.Add(b);
            BookCollection.Delete(b.ID);
            Assert.AreEqual(0, BookCollection.Get().ToList().Count());
        }

        [TestMethod()]
        public void GetTest()
        {
            ILibraryCollection<Book> BookCollection = new BookCollection(new TestDatabase());
            Book b1 = new Book { Title = "Book1", Author = "Author1" };
            Book b2 = new Book { Title = "Book2", Author = "Author1" };
            BookCollection.Add(b1);
            BookCollection.Add(b2);
            Assert.AreEqual(2, BookCollection.Get((b => b.Author == "Author1")).ToList().Count);
        }

        [TestMethod()]
        public void GetTest1()
        {
            ILibraryCollection<Book> BookCollection = new BookCollection(new TestDatabase());
            Book b1 = new Book { Title = "Book1", Author = "Author1" };
            BookCollection.Add(b1);
            Assert.IsNotNull(BookCollection.Get(b1.ID));
        }

        [TestMethod()]
        public void GetTest2()
        {
            ILibraryCollection<Book> BookCollection = new BookCollection(new TestDatabase());
            Book b1 = new Book { Title = "Book1", Author = "Author1" };
            BookCollection.Add(b1);
            Assert.IsNotNull(BookCollection.Get());
        }

        [TestMethod()]
        public void UpdateTest()
        {
            ILibraryCollection<Book> BookCollection = new BookCollection(new TestDatabase());
            Book b1 = new Book { Title = "Book1", Author = "Author1" };
            Book b2 = new Book { Title = "Book2", Author = "Author1" };
            BookCollection.Add(b1);
            b2.ID = b1.ID;
            Assert.AreEqual(b2.Title, BookCollection.Update(b2).Title);
        }
    }
}