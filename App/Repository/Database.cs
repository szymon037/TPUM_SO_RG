using System;
using System.Collections.Generic;
using System.Text;

using Model.Data;

namespace Model.Repository
{
    public class Database
    {
        public List<Book> Books { get; set; }
        public List<User> Users { get; set; }
        public List<Order> Orders { get; set; }

        public Database()
        {
            Books = new List<Book>();
            Users = new List<User>();
            Orders = new List<Order>();

            Books.Add(new Book { ID = Guid.NewGuid().ToString(), Title = "Book1", Author = "Author1" });
            Books.Add(new Book { ID = Guid.NewGuid().ToString(), Title = "Book2", Author = "Author2" });
            Books.Add(new Book { ID = Guid.NewGuid().ToString(), Title = "Book3", Author = "Author3" });
            Books.Add(new Book { ID = Guid.NewGuid().ToString(), Title = "Book4", Author = "Author4" });
            Books.Add(new Book { ID = Guid.NewGuid().ToString(), Title = "Book5", Author = "Author5" });

            Users.Add(new User { ID = Guid.NewGuid().ToString(), Name = "User1", Surname = "User1Surname", Address = "User1Address" });
            Users.Add(new User { ID = Guid.NewGuid().ToString(), Name = "User2", Surname = "User2Surname", Address = "User2Address" });

            Orders.Add(new Order { ID = Guid.NewGuid().ToString(), UserID = Users[0].ID, BookID = Books[2].ID, StartTime = new DateTime(2021, 05, 01)});
            Orders.Add(new Order { ID = Guid.NewGuid().ToString(), UserID = Users[1].ID, BookID = Books[3].ID, StartTime = new DateTime(2021, 05, 07)});
        }
    }
}
