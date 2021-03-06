using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Models
{
    internal class Order : IOrder
    {
        private static int Counter = 1;
        private static object Lock = new object();

        public Order()
        {
            lock (Lock)
            {
                ID = Counter++;
            }
        }

        public int ID { get; set; }
        public int UserID { get; set; }
        public int BookID { get; set; }
        public DateTime Start { get; set; }
        public bool Returned { get; set; }
    }
}
