using System;
using System.Collections.Generic;
using System.Text;
using Data.Models;
using Data;
using Data.Collections;

namespace DataTests
{
    internal class DataTestDatabase : IDatabase
    {
        public List<User> Users { get; set; }
        public List<Book> Books { get; set; }
        public List<Order> Orders { get; set; }

        public DataTestDatabase()
        {
            Users = new List<User>();
            Books = new List<Book>();
            Orders = new List<Order>();
        }
    }
}
