using System;
using System.Collections.Generic;
using System.Linq;

using Data.Collections;
using Data.Models;
using Logic.DataDTO;

namespace Logic.Services
{
    public class OrderService : IOrderService
    {
        private ILibraryCollection<Order> OrderCollection;
        private ILibraryCollection<Book> BookCollection;

        public OrderService()
        {
            OrderCollection = new OrderCollection();
            BookCollection = new BookCollection();
        }

        public OrderDTO GetOrder(int id)
        {
            Order order = OrderCollection.Get(id);
            return Translator.TranslateOrder(order, BookCollection.Get(order.BookID));
        }

        public IEnumerable<OrderDTO> GetOrders()
        {
            IEnumerable<Order> orders = OrderCollection.Get();

            return orders.Select(c => Translator.TranslateOrder(c, BookCollection.Get(c.BookID))).ToList();
        }

        public IEnumerable<OrderDTO> GetUserOrders(int userID)
        {
            IEnumerable<Order> orders = OrderCollection.Get();

            return orders.Where(c => c.UserID == userID).Select(c => Translator.TranslateOrder(c, BookCollection.Get(c.BookID))).ToList();
        }

        public IEnumerable<OrderDTO> GetUnfinishedOrders()
        {
            IEnumerable<Order> orders = OrderCollection.Get();

            return orders.Where(c => c.Returned == false).Select(c => Translator.TranslateOrder(c, BookCollection.Get(c.BookID))).ToList();
        }

        public BookDTO ReturnBook(OrderDTO order)
        {
            var res = OrderCollection.Get(order.ID);
            res.Returned = true;
            OrderCollection.Update(res.ID, res);
            return Translator.TranslateBook(BookCollection.Get(res.BookID));
        }

        public OrderDTO BorrowBook(BookDTO book, UserDTO user)
        {
            Order newOrder = new Order
            {
                BookID = book.ID,
                UserID = user.ID,
                Start = DateTime.Now,
                Returned = false
            };

            var res = OrderCollection.Add(newOrder);
            if (res is null) return null;
            else return Translator.TranslateOrder(res, BookCollection.Get(book.ID));
        }
    }
}
