using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DotnetMoviesAppRazor.Data
{
    public enum FilmGenre
    {
        Other,
        Action,
        Thriller,
        Comedy,
        Documentary,
        Fantasy,
        Drama,
        Detective,
        ScienceFiction
    }

    public class Film
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(128)]
        public string Title { get; set; }

        [Required]
        public int ReleaseYear { get; set; }

        [Required]
        public FilmGenre Genre { get; set; }

        [Required]
        [MaxLength(2048)]
        public string Description { get; set; }

        [Required]
        public string PosterPath { get; set; }

        // foreign keys
        public List<Person> Directors { get; set; } = new();
        public List<Review> Reviews { get; set; } = new();
        public List<Person> Actors { get; set; } = new();
        public List<User> FavouriteOfUsers { get; set; } = new();
    }
}