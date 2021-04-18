using System;
using System.Collections.Generic;
using System.Text;

using Model.Data;

namespace Model.Repository
{
    public class BookCollection : IBaseCollection<Book>
    {
        public List<Book> Books { get; set; }

        public BookCollection()
        {
            Books = new Database().Books;
        }

        public Book Add(Book entity)
        {
            if (Books.Find(c => c.ID == entity.ID) == null)
            {
                Books.Add(entity);
            }

            return entity;
        }

        public void Delete(int id)
        {
            Book book = Books.Find(c => c.ID == id);

            if (book != null)
                Books.Remove(book);
        }

        public IEnumerable<Book> Get(Predicate<Book> pred)
        {
            return Books.FindAll(pred);
        }

        public Book Get(int id)
        {
            return Books.Find(c => c.ID == id);
        }

        public Book Update(int id, Book entity)
        {
            Book book = Books.Find(c => c.ID == id);

            if (book != null)
            {
                book.Author = entity.Author;
                book.Title = entity.Title;
                book.Genre = entity.Genre;
                book.Date = entity.Date;
            }

            return book;
        }
    }
}
