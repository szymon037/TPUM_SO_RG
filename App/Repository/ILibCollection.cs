using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Repository
{
    public interface ILibCollection<T>
    {
        T Add(T entity);
        void Delete(string id);
        IEnumerable<T> Get(Predicate<T> pred);
        T Get(string id);
        T Update(string id, T entity);
    }
}
