using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Models
{
    public interface IBook
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public DateTime Date { get; set; }
    }
}
