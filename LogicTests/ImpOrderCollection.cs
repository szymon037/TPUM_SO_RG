using System;
using System.Collections.Generic;
using System.Text;

using Data.Collections;
using Data.Models;

namespace LogicTests
{
    class ImpOrderColletion : ILibraryCollection<Order>
    {
        List<Order> orders;

        public ImpOrderColletion()
        {
            orders = new List<Order>();
        }

        public Order Add(Order entity)
        {
            orders.Add(entity);
            return entity;
        }

        public void Delete(int id)
        {
        }

        public IEnumerable<Order> Get()
        {
            return orders;
        }

        public IEnumerable<Order> Get(Predicate<Order> pred)
        {
            return null;
        }

        public Order Get(int id)
        {
            return orders.Find(c => c.ID == id);
        }

        public Order Update(Order entity)
        {
            var or = Get(entity.ID);
            or.UserID = entity.UserID;
            or.BookID = entity.BookID;

            return or;
        }
    }
}
