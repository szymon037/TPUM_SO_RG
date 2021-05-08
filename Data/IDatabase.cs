using System;
using System.Collections.Generic;
using System.Text;

using Data.Models;

namespace Data
{
    public interface IDatabase
    {
        public List<IUser> Users { get; set; }
        public List<IBook> Books { get; set; }
        public List<IOrder> Orders { get; set; }
    }
}
