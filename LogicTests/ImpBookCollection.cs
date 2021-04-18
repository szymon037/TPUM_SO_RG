using System;
using System.Collections.Generic;
using System.Text;

using Data.Collections;
using Data.Models;

namespace LogicTests
{
    class ImpBookColletion : ILibraryCollection<Book>
    {
        List<Book> books;

        public ImpBookColletion()
        {
            books = new List<Book>();
        }

        public Book Add(Book entity)
        {
            books.Add(entity);
            return entity;
        }

        public void Delete(int id)
        {
        }

        public IEnumerable<Book> Get()
        {
            return books;
        }

        public IEnumerable<Book> Get(Predicate<Book> pred)
        {
            return null;
        }

        public Book Get(int id)
        {
            return books.Find(c => c.ID == id);
        }

        public Book Update(Book entity)
        {
            var bo = Get(entity.ID);
            bo.Title = entity.Title;
            bo.Author = entity.Author;

            return bo;
        }
    }
}
