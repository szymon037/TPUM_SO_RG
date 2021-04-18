using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Models
{
    public class Order : IData
    {
        public int UserID { get; set; }
        public int BookID { get; set; }
        public DateTime Start { get; set; }
        public bool Returned { get; set; }
    }
}
