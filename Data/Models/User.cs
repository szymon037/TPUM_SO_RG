using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Models
{
    internal class User : IUser
    {
        private static int Counter = 1;
        private static object Lock = new object();

        public User()
        {
            lock (Lock)
            {
                ID = Counter++;
            }
        }

        public int ID { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
    }
}
