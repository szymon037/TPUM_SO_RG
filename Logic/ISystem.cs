using System;
using System.Collections.Generic;

using Logic.DataDTO;

namespace Logic
{
    public interface ISystem
    {
        public UserDTO AddUser(UserDTO user);
        public BookDTO AddBook(BookDTO book);

        public int GetNumberOfBooks();
        public IEnumerable<UserDTO> GetUsers();
        public IEnumerable<BookDTO> GetAvailableBooks();
        public IEnumerable<OrderDTO> GetUserOrders(int userID);
        public BookDTO ReturnBook(OrderDTO order);
        public OrderDTO BorrowBook(BookDTO book, UserDTO user);
    }
}
