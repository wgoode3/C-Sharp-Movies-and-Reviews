using Microsoft.EntityFrameworkCore;
using MovieReviews.Models;
using System.Linq;

namespace MovieReviews.Models {
    public class DBContext : DbContext {
        public DBContext(DbContextOptions options) : base(options) { }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) 
        {
            optionsBuilder.UseSqlite("Filename=mydb.db");
        }
        public DbSet<Movie> Movies {get;set;}
        public DbSet<Review> Reviews {get;set;}
        public DbSet<Genre> Genres {get;set;}
        public DbSet<MovieHasGenres> MovieHasGenres {get;set;}

        public Movie GetMovieById(int MovieId)
        {
            return Movies
                .Include(m => m.Reviews)
                .Include(m => m.Genres)
                .ThenInclude(mg => mg.MovieGenre)
                .FirstOrDefault(m => m.MovieId == MovieId);
        }

    }
}