using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MovieReviews.Models
{
    public class Genre
    {
        [Key]
        public int GenreId {get;set;}
        [Required]
        public string Name {get;set;}
        public List<MovieHasGenres> Movies {get;set;}
    }
}