using System;
using System.Collections.Generic;

using Data;
using Data.Models;

namespace Data.Collections
{
    internal class OrderCollection : ILibraryCollection<IOrder>
    {
        private IDatabase Database;

        public OrderCollection()
        {
            Database = MockedDatabase.Instance;
        }

        public OrderCollection(IDatabase database)
        {
            Database = database;
        }

        public IOrder Add(IOrder entity)
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
            IOrder IOrder = Database.Orders.Find(c => c.ID == id);

            if (IOrder != null)
                Database.Orders.Remove(IOrder);
        }

        public IEnumerable<IOrder> Get(Predicate<IOrder> pred)
        {
            return Database.Orders.FindAll(pred);
        }

        public IOrder Get(int id)
        {
            return Database.Orders.Find(c => c.ID == id);
        }

        public IEnumerable<IOrder> Get()
        {
            return Database.Orders;
        }

        public IOrder Update(IOrder entity)
        {
            IOrder IOrder = Database.Orders.Find(c => c.ID == entity.ID);

            if (IOrder != null)
            {
                IOrder.BookID = entity.BookID;
                IOrder.UserID = entity.UserID;
                IOrder.Start = entity.Start;
            }

            return IOrder;
        }
    }
}
