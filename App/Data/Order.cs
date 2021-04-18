﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Data
{
    public class Order
    {
        public int ID { get; set; }
        public int UserID { get; set; }
        public int BookID { get; set; }
        public DateTime StartTime { get; set; }
        public bool Returned { get; set; }
    }
}
