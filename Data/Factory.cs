using System;
using System.Collections.Generic;
using System.Text;

using Data.Collections;
using Data.Models;

namespace Data
{
    public abstract class Factory
    {
        public static ILibraryCollection<IBook> CreateBookCollection()
        {
            return new BookCollection();
        }

        public static ILibraryCollection<IBook> CreateBookCollection(IDatabase database)
        {
            return new BookCollection(database);
        }

        public static ILibraryCollection<IOrder> CreateOrderCollection()
        {
            return new OrderCollection();
        }

        public static ILibraryCollection<IOrder> CreateOrderCollection(IDatabase database)
        {
            return new OrderCollection(database);
        }

        public static ILibraryCollection<IUser> CreateUserCollection()
        {
            return new UserCollection();
        }

        public static ILibraryCollection<IUser> CreateUserCollection(IDatabase database)
        {
            return new UserCollection(database);
        }

        public static IUser CreateUser(string name, string address)
        {
            return new User { Name = name, Address = address };
        }

        public static IBook CreateBook(string title, string author, DateTime date)
        {
            return new Book { Title = title, Author = author, Date = date };
        }

        public static IOrder CreateOrder(int userID, int bookID, bool returned)
        {
            return new Order { UserID = userID, BookID = bookID, Start = DateTime.Now, Returned = returned };
        }
    }
}
