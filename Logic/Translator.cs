using System;
using System.Collections.Generic;
using System.Text;

using Logic.DataDTO;
using Data.Models;

namespace Logic
{
    internal static class Translator
    {
        internal static UserDTO TranslateUser(IUser user)
        {
            UserDTO result = new UserDTO
            {
                ID = user.ID,
                Name = user.Name,
                Address = user.Address
            };

            return result;
        }

        internal static BookDTO TranslateBook(IBook book)
        {
            BookDTO result = new BookDTO
            {
                ID = book.ID,
                Title = book.Title,
                Author = book.Author,
                Date = book.Date
            };

            return result;
        }

        internal static OrderDTO TranslateOrder(IOrder order, IBook book)
        {
            OrderDTO result = new OrderDTO
            {
                ID = order.ID,
                UserID = order.UserID,
                Book = TranslateBook(book),
                DaysBorrowed = (DateTime.Now - order.Start).Days,
                Returned = order.Returned
            };

            return result;
        }
    }
}
