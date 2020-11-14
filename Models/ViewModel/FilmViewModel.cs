using DotnetMoviesAppRazor.Data;
using System.Collections.Generic;
using System.Linq;

namespace DotnetMoviesAppRazor.Models.ViewModel
{
    public class FilmViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int ReleaseYear { get; set; }
        public string Genre { get; set; }
        public string Description { get; set; }
        public string PosterPath { get; set; }

        public List<string> Directors { get; set; } = new();
        public List<string> Actors { get; set; } = new();
        public List<ReviewViewModel> Reviews { get; set; } = new();

        public FilmViewModel(Film film)
        {
            Id = film.Id;
            Title = film.Title;
            ReleaseYear = film.ReleaseYear;
            Genre = GenreToString(film.Genre);
            Description = film.Description;
            PosterPath = film.PosterPath;

            Directors = film.Directors.Select(d => d.Name).ToList();
            Actors = film.Actors.Select(a => a.Name).ToList();
            Reviews = film.Reviews.Select(r => new ReviewViewModel(r, ReviewViewModel.Caller.Film)).ToList();
        }

        public static string GenreToString(FilmGenre genre)
        {
            return genre switch
            {
                FilmGenre.Action => "Action",
                FilmGenre.Comedy => "Comedy",
                FilmGenre.Documentary => "Documentary",
                FilmGenre.Drama => "Drama",
                FilmGenre.Fantasy => "Fantasy",
                FilmGenre.Thriller => "Thriller",
                FilmGenre.Detective => "Detective",
                FilmGenre.ScienceFiction => "Science Fiction",
                FilmGenre.Other => "Other",
                _ => "Other"
            };
        }
    }
}
