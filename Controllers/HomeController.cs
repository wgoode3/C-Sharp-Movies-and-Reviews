using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MovieReviews.Models;

namespace MovieReviews.Controllers
{
    public class HomeController : Controller
    {

        private static DBContext context;

        public HomeController(DBContext DBContext)
        {
            context = DBContext;
        }

        [HttpGet("")]
        public IActionResult Index()
        {
            ViewBag.Movies = context.Movies;
            return View();
        }

        [HttpPost("movie")]
        public IActionResult CreateMovie(Movie m)
        {
            if(ModelState.IsValid)
            {
                context.Movies.Add(m);
                context.SaveChanges();
            }
            return Redirect("/");
        }

        [HttpGet("movie/{MovieId}")]
        public IActionResult GetMovie(int MovieId)
        {
            ViewBag.Genres = context.Genres;
            ViewBag.Movie = context.GetMovieById(MovieId);
            return View();
        }

        [HttpPost("review")]
        public IActionResult ReviewMovie(Review r)
        {
            if(ModelState.IsValid)
            {
                context.Reviews.Add(r);
                context.SaveChanges();
                Console.WriteLine(r.MovieId);
            }
            return Redirect("/");
        }

        [HttpGet("genre")]
        public IActionResult GenreForm()
        {
            ViewBag.Genres = context.Genres;
            return View();
        }

        [HttpPost("genre")]
        public IActionResult CreateGenre(Genre g)
        {
            context.Genres.Add(g);
            context.SaveChanges();
            return Redirect("/genre");
        }

        [HttpPost("add_genre/{MovieId}")]
        public IActionResult AddGenre(int MovieId, int GenreId)
        {
            int matches = context.MovieHasGenres.Where(g => g.MovieId == MovieId).Where(g => g.GenreId == GenreId).Count(); 
            if(matches == 0)
            {
                MovieHasGenres mg = new MovieHasGenres(MovieId, GenreId);
                context.MovieHasGenres.Add(mg);
                context.SaveChanges();
            }
            return Redirect("/");
        }


    }
}
