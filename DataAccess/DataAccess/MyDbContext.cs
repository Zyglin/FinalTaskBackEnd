using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebFilms.DataAccess.Entity;

namespace WebFilms.DataAccess
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            string[] GenreTypes = new[] { "Action", "Drama", "Comedy", "Adventure", "Documentaly", "Horror", "Romance" };
            Guid GUID_FOR_ACTION = Guid.NewGuid(); 

                 modelBuilder.Entity<User>().HasData(
                 new User
                {
                    Id = Guid.NewGuid(),
                    Email = "zyglin@mail.ru",
                    PasswordHash = PBKDF2Helper.CalculateHash("password")
                }
                );

                 modelBuilder.Entity<Genre>().HasData(
                 new Genre
                  {
                      Id = GUID_FOR_ACTION,
                     Name = GenreTypes[0],
                  }
                  );

            for (int i = 2; i < GenreTypes.Length+1; i++)
            {
                modelBuilder.Entity<Genre>().HasData(
                new Genre
                {
                    Id = Guid.NewGuid(),
                    Name = GenreTypes[i-1],
                }
                );
            }

            modelBuilder.Entity<Film>().HasData(
            new Film
            {
                Id = Guid.NewGuid(),
                Name = "Star Wars",
                GenreId = GUID_FOR_ACTION,
            }
                );
        }
   
        public DbSet<User> Users { get; set; }
        public DbSet<Film> Films { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Comment> Comments { get; set; }
    }
}
