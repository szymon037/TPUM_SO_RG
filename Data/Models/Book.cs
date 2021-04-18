using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Models
{
    public class Book : IData
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public DateTime Date { get; set; }

    }
}
