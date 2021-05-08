using System;
using System.Collections.Generic;
using System.Text;

using Data.Collections;
using Data.Models;

namespace LogicTests
{
    class ImpOrderColletion : ILibraryCollection<IOrder>
    {
        List<IOrder> orders;

        public ImpOrderColletion()
        {
            orders = new List<IOrder>();
        }

        public IOrder Add(IOrder entity)
        {
            orders.Add(entity);
            return entity;
        }

        public void Delete(int id)
        {
        }

        public IEnumerable<IOrder> Get()
        {
            return orders;
        }

        public IEnumerable<IOrder> Get(Predicate<IOrder> pred)
        {
            return null;
        }

        public IOrder Get(int id)
        {
            return orders.Find(c => c.ID == id);
        }

        public IOrder Update(IOrder entity)
        {
            var or = Get(entity.ID);
            or.UserID = entity.UserID;
            or.BookID = entity.BookID;

            return or;
        }
    }
}
