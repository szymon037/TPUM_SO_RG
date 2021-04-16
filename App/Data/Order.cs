using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Data
{
    public class Order
    {
        public string ID { get; set; }
        public string UserID { get; set; }
        public string BookID { get; set; }
        public DateTime StartTime { get; set; }
        public bool Returned { get; set; }
    }
}
