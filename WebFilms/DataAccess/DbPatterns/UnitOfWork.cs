using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebFilms.DataAccess.DbPatterns.Interfaces;
using WebFilms.DataAccess.Entity;

namespace WebFilms.DataAccess.DbPatterns
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly MyDbContext _context;

        public UnitOfWork(MyDbContext context)
        {
            _context = context;
        }
        public IGenericRepository<User> Users => new GenericRepository<User>(_context);

        public IGenericRepository<Film> Films => new GenericRepository<Film>(_context);

        public IGenericRepository<Genre> Genres => new GenericRepository<Genre>(_context);

        public IGenericRepository<Comment> Comments => new GenericRepository<Comment>(_context);

        public void Save()
        {
            _context.SaveChanges();
        }

    }
}
