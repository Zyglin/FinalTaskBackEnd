using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebFilms.DataAccess.DbPatterns.Interfaces;

namespace WebFilms.Services.Service
{
    public class ServiceConstructor
    {
        protected IUnitOfWork UnitOfWork;

        protected ServiceConstructor(IUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
        }
    }
}
