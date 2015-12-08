using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormationEF
{
    interface IRepository<T>
    {
        T GetById(int id);
        IEnumerable<T> GetAll();
        IEnumerable<T> GetByLambda(Func<T, bool> where);
        T Insert(T entity);
        void Remove(T entity);
        void Save();
    }
}
