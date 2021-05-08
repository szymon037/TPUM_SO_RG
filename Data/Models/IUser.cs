using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Models
{
    public interface IUser
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
    }
}
