using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Models
{
    internal class Book : IBook
    {
        private static int Counter = 1;
        private static object Lock = new object();

        public Book()
        {
            lock (Lock)
            {
                ID = Counter++;
            }
        }

        public int ID { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public DateTime Date { get; set; }

    }
}
