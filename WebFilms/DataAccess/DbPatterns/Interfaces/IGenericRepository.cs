using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebFilms.DataAccess.DbPatterns.Interfaces
{
    public interface IGenericRepository<T>
    {
        void Create(T t);
        void Delete(T t);
        T Get(string id);
        IEnumerable<T> GetAll();
        void Update(T t);
        //IEnumerable<T> Filter(Expression<Func<T, bool>> predicate, params string[] navigationProperties);
        //IEnumerable<T> FilterTwo(params string[] navigationProperties);
    }
}
