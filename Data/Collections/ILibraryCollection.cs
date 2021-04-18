using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Collections
{
    public interface ILibraryCollection<T>
    {
        T Add(T entity);
        void Delete(int id);
        IEnumerable<T> Get();
        IEnumerable<T> Get(Predicate<T> pred);
        T Get(int id);
        T Update(T entity);
    }
}
