using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace MoviesApp.Models
{
    public class User : IdentityUser<int>
    {
        public User() : base()
        {
            FilmReviews = new List<FilmReview>();
            Favorites = new List<Favorite>();
        }

        public List<FilmReview> FilmReviews { get; set; }
        public List<Favorite> Favorites { get; set; }
    }
}