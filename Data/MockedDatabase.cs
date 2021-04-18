using Data.Models;
using System;
using System.Collections.Generic;

namespace Data
{
    internal class MockedDatabase : IDatabase
    {
        public List<User> Users { get; set; }
        public List<Book> Books { get; set; }
        public List<Order> Orders { get; set; }

        private static MockedDatabase _Instance = null;
        private static readonly object LockObject = new object();

        public static MockedDatabase Instance
        {
            get
            {
                lock (LockObject)
                {
                    if (_Instance == null)
                        _Instance = new MockedDatabase();
                }

                return _Instance;
            }
        }

        MockedDatabase()
        {
            Books = new List<Book>();
            Users = new List<User>();
            Orders = new List<Order>();

            Books.Add(new Book { Title = "Book1", Author = "Author1" });
            Books.Add(new Book { Title = "Book2", Author = "Author2" });
            Books.Add(new Book { Title = "Book3", Author = "Author3" });
            Books.Add(new Book { Title = "Book4", Author = "Author4" });
            Books.Add(new Book { Title = "Book5", Author = "Author5" });

            Users.Add(new User { Name = "User1", Address = "User1Address" });
            Users.Add(new User { Name = "User2", Address = "User2Address" });

            Orders.Add(new Order { UserID = Users[0].ID, BookID = Books[2].ID, Start = new DateTime(2021, 04, 01) });
            Orders.Add(new Order { UserID = Users[1].ID, BookID = Books[3].ID, Start = new DateTime(2021, 04, 07) });
        }
    }
}
