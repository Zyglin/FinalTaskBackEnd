using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebFilms.DataAccess.DbPatterns.Interfaces;

namespace WebFilms.DataAccess.DbPatterns
{

    public class GenericRepository<T> :
  IGenericRepository<T> where T : class
    {
        private readonly MyDbContext _context;

        public GenericRepository(MyDbContext context)
        {
            _context = context;
        }

        public void Create(T t)
        {
            _context.Set<T>().Add(t);
            _context.SaveChanges();
        }

        public void Delete(T t)
        {
            if (t != null)
            {
                _context.Set<T>().Remove(t);
                _context.SaveChanges();
            }
        }

        public T Get(string id)
        {
            return _context.Set<T>().Find(id);
        }

        public IEnumerable<T> GetAll()
        {
            return _context.Set<T>();
        }


        public void Update(T t)
        {
            _context.Entry(t).State = EntityState.Modified;
            _context.SaveChanges();
        }

        //public IEnumerable<T> Filter(Expression<Func<T, bool>> predicate, params string[] navigationProperties)
        //{
        //    var query = _context.Set<T>().AsQueryable();
        //    foreach (var navigationProperty in navigationProperties)
        //    {
        //        query = query.Include(navigationProperty);
        //    }
        //    var list = query.Where(predicate).ToList();
        //    return list;
        //}

        //public IEnumerable<T> FilterTwo(params string[] navigationProperties)
        //{
        //    var query = _context.Set<T>().AsQueryable();
        //    foreach (var navigationProperty in navigationProperties)
        //    {
        //        query = query.Include(navigationProperty);
        //    }
        //    var list = query.ToList();
        //    return list;
        //}
    }
}
