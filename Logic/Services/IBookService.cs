using System;
using System.Collections.Generic;
using System.Text;

using Logic.DataDTO;

namespace Logic.Services
{
    public interface IBookService
    {
        public BookDTO AddBook(BookDTO book);
        public BookDTO GetBook(int id);
        public int GetNumberOfBooks();
        public IEnumerable<BookDTO> GetBooks();
        public IEnumerable<BookDTO> GetBooksByAuthor(string author);
        public IEnumerable<BookDTO> GetAvailableBooks();
    }
}
