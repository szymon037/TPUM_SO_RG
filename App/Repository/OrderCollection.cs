using System;
using System.Collections.Generic;
using System.Text;

using Model.Data;

namespace Model.Repository
{
    public class OrderCollection : IBaseCollection<Order>
    {
        public List<Order> Orders { get; set; }

        public OrderCollection()
        {
            Orders = new Database().Orders;
        }

        public Order Add(Order entity)
        {
            if (Orders.Find(c => c.ID == entity.ID) == null)
            {
                Orders.Add(entity);
            }

            return entity;
        }

        public void Delete(int id)
        {
            Order order = Orders.Find(c => c.ID == id);

            if (order != null)
                Orders.Remove(order);
        }

        public IEnumerable<Order> Get(Predicate<Order> pred)
        {
            return Orders.FindAll(pred);
        }

        public Order Get(int id)
        {
            return Orders.Find(c => c.ID == id);
        }

        public Order Update(int id, Order entity)
        {
            Order order = Orders.Find(c => c.ID == id);

            if (order != null)
            {
                order.BookID = entity.BookID;
                order.UserID = entity.UserID;
                order.StartTime = entity.StartTime;
            }

            return order;
        }
    }
}
