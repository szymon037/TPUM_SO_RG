using System;
using System.Collections.Generic;

using Data;
using Data.Models;

namespace Data.Collections
{
    public class OrderCollection : ILibraryCollection<Order>
    {
        private IDatabase Database;

        public OrderCollection()
        {
            Database = MockedDatabase.Instance;
        }

        public Order Add(Order entity)
        {
            if (Database.Orders.Find(c => c.UserID == entity.UserID && c.BookID == entity.BookID) == null)
            {
                Database.Orders.Add(entity);
                return entity;
            }

            return null;
        }

        public void Delete(int id)
        {
            Order order = Database.Orders.Find(c => c.ID == id);

            if (order != null)
                Database.Orders.Remove(order);
        }

        public IEnumerable<Order> Get(Predicate<Order> pred)
        {
            return Database.Orders.FindAll(pred);
        }

        public Order Get(int id)
        {
            return Database.Orders.Find(c => c.ID == id);
        }

        public IEnumerable<Order> Get()
        {
            return Database.Orders;
        }

        public Order Update(int id, Order entity)
        {
            Order order = Database.Orders.Find(c => c.ID == id);

            if (order != null)
            {
                order.BookID = entity.BookID;
                order.UserID = entity.UserID;
                order.Start = entity.Start;
            }

            return order;
        }
    }
}
