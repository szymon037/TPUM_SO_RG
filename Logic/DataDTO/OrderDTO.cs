using System;
using System.Collections.Generic;
using System.Text;

namespace Logic.DataDTO
{
    public class OrderDTO
    {
        public int ID { get; set; }
        public int UserID { get; set; }
        public BookDTO Book { get; set; }
        public int DaysBorrowed { get; set; }
        public bool Returned { get; set; }
    }
}
