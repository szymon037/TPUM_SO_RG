using System;
using System.Collections.Generic;

using Data;
using Data.Models;

namespace Data.Collections
{
    internal class BookCollection : ILibraryCollection<IBook>
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

        public IBook Add(IBook entity)
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
            IBook book = Database.Books.Find(c => c.ID == id);

            if (book != null)
                Database.Books.Remove(book);
        }

        public IEnumerable<IBook> Get(Predicate<IBook> pred)
        {
            return Database.Books.FindAll(pred);
        }

        public IBook Get(int id)
        {
            return Database.Books.Find(c => c.ID == id);
        }

        public IEnumerable<IBook> Get()
        {
            return Database.Books;
        }

        public IBook Update(IBook entity)
        {
            IBook book = Database.Books.Find(c => c.ID == entity.ID);

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
