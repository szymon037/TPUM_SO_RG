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
        public List<IUser> Users { get; set; }
        public List<IBook> Books { get; set; }
        public List<IOrder> Orders { get; set; }

        public DataTestDatabase()
        {
            Users = new List<IUser>();
            Books = new List<IBook>();
            Orders = new List<IOrder>();
        }
    }
}
