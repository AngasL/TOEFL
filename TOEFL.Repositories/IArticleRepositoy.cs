using System;
using System.Collections.Generic;
using System.Text;

namespace TOEFL.Repositories
{
    public interface IRepository<T>
    {
        T Get(int id);
        T Add(T item);
        IEnumerable<T> AddRange(IEnumerable<T> items);
        T Update(T item);
        bool Delete(int id);
    }
}
