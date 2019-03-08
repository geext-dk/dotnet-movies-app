using System;
using System.ComponentModel.DataAnnotations;

namespace MoviesApp.Models
{
    public class FilmReview
    {
        public int FilmReviewId { get; set; }
        
        [Required]
        [MaxLength(2048)]

        public string Title { get; set; }
        public string Body { get; set; }

        public int FilmId { get; set; }
        public Film Film { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }

    }
}