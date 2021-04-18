﻿using System;
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
        private ILibraryCollection<Order> OrderCollection;
        private ILibraryCollection<Book> BookCollection;

        public OrderSystem()
        {
            OrderCollection = new OrderCollection();
            BookCollection = new BookCollection();
        }

        public OrderSystem(IDatabase database)
        {
            OrderCollection = new OrderCollection(database);
            BookCollection = new BookCollection(database);
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
            OrderCollection.Update(res);
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
