using System;
using System.Collections.Generic;
using System.Text;

using Data.Collections;
using Data.Models;

namespace LogicTests
{
    class ImpBookColletion : ILibraryCollection<IBook>
    {
        List<IBook> books;

        public ImpBookColletion()
        {
            books = new List<IBook>();
        }

        public IBook Add(IBook entity)
        {
            books.Add(entity);
            return entity;
        }

        public void Delete(int id)
        {
        }

        public IEnumerable<IBook> Get()
        {
            return books;
        }

        public IEnumerable<IBook> Get(Predicate<IBook> pred)
        {
            return null;
        }

        public IBook Get(int id)
        {
            return books.Find(c => c.ID == id);
        }

        public IBook Update(IBook entity)
        {
            var bo = Get(entity.ID);
            bo.Title = entity.Title;
            bo.Author = entity.Author;

            return bo;
        }
    }
}
