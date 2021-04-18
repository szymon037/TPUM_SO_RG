using System.Collections.Generic;
using System.Linq;

using Logic.Services;
using Logic.DataDTO;

namespace Logic
{
    public class LibrarySystem : ISystem
    {
        private UserService _UserService;
        private BookService _BookService;
        private OrderService _OrderService;

        public LibrarySystem()
        {
            _UserService = new UserService();
            _BookService = new BookService();
            _OrderService = new OrderService();
        }

        public IEnumerable<UserDTO> GetUsers()
        {
            return _UserService.GetUsers();
        }

        public int GetNumberOfBooks()
        {
            return _BookService.GetBooks().Count();
        }

        public IEnumerable<BookDTO> GetAvailableBooks()
        {
            var orders = _OrderService.GetUnfinishedOrders();
            var books = _BookService.GetBooks();

            for (int i = 0; i < orders.Count(); i++)
            {
                books = books.Where(book => book.ID != orders.ElementAt(i).Book.ID).ToList();
            }

            return books;
        }

        public IEnumerable<OrderDTO> GetUserOrders(int userID)
        {
            return _OrderService.GetUserOrders(userID);
        }

        public UserDTO AddUser(UserDTO user)
        {
            return _UserService.AddUser(user);
        }

        public BookDTO AddBook(BookDTO book)
        {
            return _BookService.AddBook(book);
        }

        public BookDTO ReturnBook(OrderDTO order)
        {
            return _OrderService.ReturnBook(order);
        }

        public OrderDTO BorrowBook(BookDTO book, UserDTO user)
        {
            return _OrderService.BorrowBook(book, user);
        }
    }
}
