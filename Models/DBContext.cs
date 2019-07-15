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

        public Movie GetMovieById(int MovieId)
        {
            return Movies.Include(m => m.Reviews).FirstOrDefault(m => m.MovieId == MovieId);
        }

    }
}