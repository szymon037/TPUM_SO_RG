using System.Collections.Generic;
using System.Linq;

using Data.Collections;
using Data.Models;
using Logic.DataDTO;

namespace Logic.Services
{
    public class BookService : IBookService
    {
        private ILibraryCollection<Book> BookCollection;
        private ILibraryCollection<Order> OrderCollection;

        public BookService()
        {
            BookCollection = new BookCollection();
            OrderCollection = new OrderCollection();
        }

        public BookDTO AddBook(BookDTO book)
        {
            Book newBook = new Book
            {
                Title = book.Title,
                Author = book.Author,
                Date = book.Date
            };

            var res = BookCollection.Add(newBook);
            if (res is null) return null;
            else return Translator.TranslateBook(res);
        }

        public BookDTO GetBook(int id)
        {
            return Translator.TranslateBook(BookCollection.Get(id));
        }

        public int GetNumberOfBooks()
        {
            return GetBooks().Count();
        }

        public IEnumerable<BookDTO> GetBooks()
        {
            IEnumerable<Book> books = BookCollection.Get();

            return books.Select(c => Translator.TranslateBook(c)).ToList();
        }

        public IEnumerable<BookDTO> GetBooksByAuthor(string author)
        {
            IEnumerable<Book> books = BookCollection.Get();

            return books.Where(c => c.Author == author).Select(c => Translator.TranslateBook(c)).ToList();
        }

        public IEnumerable<BookDTO> GetAvailableBooks()
        {
            IEnumerable<OrderDTO> orders = OrderCollection.Get().Where(c => c.Returned == false).Select(c => Translator.TranslateOrder(c, BookCollection.Get(c.BookID)));
            IEnumerable<BookDTO> books = GetBooks();

            for (int i = 0; i < orders.Count(); i++)
            {
                books = books.Where(book => book.ID != orders.ElementAt(i).Book.ID).ToList();
            }

            return books;
        }
    }
}
