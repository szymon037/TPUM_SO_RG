using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Data
{
    public enum BookGenre 
    {
        THRILLER, FANTASY, HISTORICAL, SCIENCE_FICTION
    }

    public class Book
    {
        public string ID { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public BookGenre Genre { get; set; }
        public DateTime Date { get; set; }
    }
}
