using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Models
{
    public interface IOrder
    {
        public int ID { get; set; }
        public int UserID { get; set; }
        public int BookID { get; set; }
        public DateTime Start { get; set; }
        public bool Returned { get; set; }
    }
}
