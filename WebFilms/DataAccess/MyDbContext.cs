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

                    modelBuilder.Entity<User>().HasData(
            new User
            {
                Id = Guid.NewGuid().ToString(),
                Email = "zyglin@mail.ru",
                PasswordHash = PBKDF2Helper.CalculateHash("password")
            }
                );

            for (int i = 1; i < GenreTypes.Length+1; i++)
            {
                modelBuilder.Entity<Genre>().HasData(
                new Genre
                {
                    GenreId = i,
                    Name = GenreTypes[i-1],
                }
                );
            }

            modelBuilder.Entity<Film>().HasData(
            new Film
            {
                FilmId = Guid.NewGuid().ToString(),
                Name = "Star Wars",
                GenreId = 3,
            }
                );
        }
   
        public DbSet<User> Users { get; set; }
        public DbSet<Film> Films { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Comment> Comments { get; set; }
    }
}
