using System;
using System.ComponentModel.DataAnnotations;

namespace MovieReviews.Models
{
    public class Review
    {
        [Key]
        public int ReviewId {get;set;}
        [Required]
        public string Name {get;set;}
        [Required]
        public int Rating {get;set;}
        public string Comment {get;set;}
        public DateTime CreatedAt {get;set;} = DateTime.Now;
        public DateTime UpdatedAt {get;set;} = DateTime.Now;
        public int MovieId {get;set;}
        public Movie ReviewedMovie;
    }
}