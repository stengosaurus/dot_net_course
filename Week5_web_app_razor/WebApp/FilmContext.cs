using Microsoft.EntityFrameworkCore;
using FilmEntities;

namespace FilmContext
{
    public class FilmsDatabase : DbContext
    {
        public DbSet<Film> Films { get; set; }
        public DbSet<Actor> Actors { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Filename=Films.db");
        }
    }
}
