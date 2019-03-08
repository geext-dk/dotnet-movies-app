using System;
using System.ComponentModel.DataAnnotations;
using MoviesApp.Models;

namespace MoviesApp.ViewModels
{
    public class AddReviewModel
    {
        [Required]
        public int FilmId { get; set; }

        [Required]
        [MaxLength(80)]
        public string Title { get; set; }

        [Required]
        public string Body { get; set; }

    }
}