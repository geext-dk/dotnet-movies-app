using System;

namespace MoviesApp.Models
{
    public class Favorite
    {
        public int FilmId { get; set; }
        public Film Film { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }
    }
}