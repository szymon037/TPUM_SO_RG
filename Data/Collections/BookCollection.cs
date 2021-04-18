using System;
using System.Collections.Generic;

using Data;
using Data.Models;

namespace Data.Collections
{
    public class BookCollection : ILibraryCollection<Book>
    {
        private IDatabase Database;

        public BookCollection()
        {
            Database = MockedDatabase.Instance;
        }

        public BookCollection(IDatabase database)
        {
            Database = database;
        }

        public Book Add(Book entity)
        {
            if (Database.Books.Find(c => c.Title.Equals(entity.Title)) == null)
            {
                Database.Books.Add(entity);
                return entity;
            }

            return null;
        }

        public void Delete(int id)
        {
            Book book = Database.Books.Find(c => c.ID == id);

            if (book != null)
                Database.Books.Remove(book);
        }

        public IEnumerable<Book> Get(Predicate<Book> pred)
        {
            return Database.Books.FindAll(pred);
        }

        public Book Get(int id)
        {
            return Database.Books.Find(c => c.ID == id);
        }

        public IEnumerable<Book> Get()
        {
            return Database.Books;
        }

        public Book Update(int id, Book entity)
        {
            Book book = Database.Books.Find(c => c.ID == id);

            if (book != null)
            {
                book.Author = entity.Author;
                book.Title = entity.Title;
                book.Date = entity.Date;
            }

            return book;
        }
    }
}
