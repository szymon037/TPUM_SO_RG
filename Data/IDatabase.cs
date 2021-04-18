using System;
using System.Collections.Generic;
using System.Text;

using Data.Models;

namespace Data
{
    public interface IDatabase
    {
        public List<User> Users { get; set; }
        public List<Book> Books { get; set; }
        public List<Order> Orders { get; set; }
    }
}
