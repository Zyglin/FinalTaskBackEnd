using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebFilms.DataAccess.Entity;

namespace WebFilms.Services.Interface
{
    public interface IFilmService
    {
        IEnumerable<Film> GetAllFilms();
    }
}
