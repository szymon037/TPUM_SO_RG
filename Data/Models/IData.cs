using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Models
{
    public abstract class IData
    {
        private static int Counter = 1;
        private static object Lock = new object();

        public int ID { get; private set; }

        public IData()
        {
            lock (Lock)
            {
                ID = Counter++;
            }
        }
    }
}
