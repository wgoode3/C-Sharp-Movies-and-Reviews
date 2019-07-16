using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MovieReviews.Models
{
    public class MovieHasGenres
    {
        [Key]
        public int MovieHasGenresId {get; set;}
        public int MovieId {get; set;}
        public Movie MovieInGenre {get; set;}
        public int GenreId {get; set;}
        public Genre MovieGenre {get; set;}

        public MovieHasGenres(int MovieId, int GenreId)
        {
            this.MovieId = MovieId;
            this.GenreId = GenreId;
        }
    }
}