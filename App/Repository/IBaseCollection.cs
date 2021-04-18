using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Repository
{
    public interface IBaseCollection<T>
    {
        T Add(T entity);
        void Delete(int id);
        IEnumerable<T> Get(Predicate<T> pred);
        T Get(int id);
        T Update(int id, T entity);
    }
}
