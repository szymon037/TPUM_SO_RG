using System.Collections.Generic;
using System.Linq;

using Data.Collections;
using Data.Models;
using Data;
using Logic.DataDTO;

namespace Logic.Systems
{
    public class BookSystem : IBookSystem
    {
        private ILibraryCollection<IBook> BookCollection;
        private ILibraryCollection<IOrder> OrderCollection;

        public BookSystem()
        {
            BookCollection = Factory.CreateBookCollection();
            OrderCollection = Factory.CreateOrderCollection();
        }

        public BookSystem(ILibraryCollection<IBook> bC, ILibraryCollection<IOrder> oC)
        {
            BookCollection = bC;
            OrderCollection = oC;
        }

        public BookDTO AddBook(BookDTO book)
        {
            IBook newBook = Factory.CreateBook(book.Title, book.Author, book.Date);

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
            IEnumerable<IBook> books = BookCollection.Get();

            return books.Select(c => Translator.TranslateBook(c)).ToList();
        }

        public IEnumerable<BookDTO> GetBooksByAuthor(string author)
        {
            IEnumerable<IBook> books = BookCollection.Get();

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
