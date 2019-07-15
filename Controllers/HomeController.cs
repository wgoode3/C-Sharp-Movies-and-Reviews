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


    }
}
