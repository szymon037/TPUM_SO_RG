using System;
using System.Collections.Generic;
using System.Text;

using Logic.DataDTO;

namespace Logic.Systems
{
    public interface IOrderSystem
    {
        public IEnumerable<OrderDTO> GetOrders();
        public IEnumerable<OrderDTO> GetUserOrders(int userID);
        public IEnumerable<OrderDTO> GetUnfinishedOrders();
        public BookDTO ReturnBook(OrderDTO order);
        public OrderDTO BorrowBook(BookDTO book, UserDTO user);
    }
}
