using System;

namespace MoviesApp.Models
{
    public class FilmActorJoin
    {
        public int FilmId { get; set; }
        public Film Film { get; set; }

        public int PersonId { get; set; }
        public Person Person { get; set; }
    }
}