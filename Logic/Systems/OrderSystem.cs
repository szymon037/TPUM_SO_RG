using System;
using System.Collections.Generic;
using System.Linq;

using Data.Collections;
using Data.Models;
using Data;
using Logic.DataDTO;

namespace Logic.Systems
{
    public class OrderSystem : IOrderSystem
    {
        private ILibraryCollection<IBook> BookCollection;
        private ILibraryCollection<IOrder> OrderCollection;

        public OrderSystem()
        {
            BookCollection = Factory.CreateBookCollection();
            OrderCollection = Factory.CreateOrderCollection();
        }

        public OrderSystem(ILibraryCollection<IBook> bC, ILibraryCollection<IOrder> oC)
        {
            BookCollection = bC;
            OrderCollection = oC;
        }

        public OrderDTO GetOrder(int id)
        {
            IOrder order = OrderCollection.Get(id);
            return Translator.TranslateOrder(order, BookCollection.Get(order.BookID));
        }

        public IEnumerable<OrderDTO> GetOrders()
        {
            IEnumerable<IOrder> orders = OrderCollection.Get();

            return orders.Select(c => Translator.TranslateOrder(c, BookCollection.Get(c.BookID))).ToList();
        }

        public IEnumerable<OrderDTO> GetUserOrders(int userID)
        {
            IEnumerable<IOrder> orders = OrderCollection.Get();

            return orders.Where(c => c.UserID == userID).Select(c => Translator.TranslateOrder(c, BookCollection.Get(c.BookID))).ToList();
        }

        public IEnumerable<OrderDTO> GetUnfinishedOrders()
        {
            IEnumerable<IOrder> orders = OrderCollection.Get();

            return orders.Where(c => c.Returned == false).Select(c => Translator.TranslateOrder(c, BookCollection.Get(c.BookID))).ToList();
        }

        public BookDTO ReturnBook(OrderDTO order)
        {
            var res = OrderCollection.Get(order.ID);
            order.Returned = true;
            res.Returned = true;
            OrderCollection.Update(res);
            return Translator.TranslateBook(BookCollection.Get(res.BookID));
        }

        public OrderDTO BorrowBook(BookDTO book, UserDTO user)
        {
            IOrder newOrder = Factory.CreateOrder(book.ID, user.ID, false);

            var res = OrderCollection.Add(newOrder);
            if (res is null) return null;
            else return Translator.TranslateOrder(res, BookCollection.Get(book.ID));
        }
    }
}
