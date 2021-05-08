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
            ILibraryCollection<IBook> BookCollection = Factory.CreateBookCollection(new DataTestDatabase());
            BookCollection.Add(Factory.CreateBook("Book1", "Author1", DateTime.Now));
            Assert.IsNotNull(BookCollection.Get((b => b.Title == "Book1")));
        }

        [TestMethod()]
        public void DeleteTest()
        {
            ILibraryCollection<IBook> BookCollection = Factory.CreateBookCollection(new DataTestDatabase());
            IBook b = BookCollection.Add(Factory.CreateBook("Book1", "Author1", DateTime.Now));
            BookCollection.Delete(b.ID);

            Assert.AreEqual(0, BookCollection.Get().ToList().Count());
        }

        [TestMethod()]
        public void GetTest()
        {
            ILibraryCollection<IBook> BookCollection = Factory.CreateBookCollection(new DataTestDatabase());
            BookCollection.Add(Factory.CreateBook("Book1", "Author1", DateTime.Now));
            BookCollection.Add(Factory.CreateBook("Book2", "Author1", DateTime.Now));

            Assert.AreEqual(2, BookCollection.Get((b => b.Author == "Author1")).ToList().Count);
        }

        [TestMethod()]
        public void GetTest1()
        {
            ILibraryCollection<IBook> BookCollection = Factory.CreateBookCollection(new DataTestDatabase());
            IBook b1 = BookCollection.Add(Factory.CreateBook("Book1", "Author1", DateTime.Now));

            Assert.IsNotNull(BookCollection.Get(b1.ID));
        }

        [TestMethod()]
        public void GetTest2()
        {
            ILibraryCollection<IBook> BookCollection = Factory.CreateBookCollection(new DataTestDatabase());
            BookCollection.Add(Factory.CreateBook("Book1", "Author1", DateTime.Now));

            Assert.AreEqual(1, BookCollection.Get().Count());
        }

        [TestMethod()]
        public void UpdateTest()
        {
            ILibraryCollection<IBook> BookCollection = Factory.CreateBookCollection(new DataTestDatabase());
            IBook b1 = BookCollection.Add(Factory.CreateBook("Book1", "Author1", DateTime.Now));
            IBook b2 = Factory.CreateBook("Book2", "Author2", DateTime.Now);
            b2.ID = b1.ID;

            Assert.AreEqual(b2.Title, BookCollection.Update(b2).Title);
        }
    }
}