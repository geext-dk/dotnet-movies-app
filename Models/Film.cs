using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace MoviesApp.Models
{
    public enum FilmGenre {
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
        public Film()
        {
            FilmActors = new List<FilmActorJoin>();
            FilmDirectors = new List<FilmDirectorJoin>();
            FilmReviews = new List<FilmReview>();
        }
        public int FilmId { get; set; }

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

        public string stringDirectors()
        {
            var ret = "";
            int i;
            for (i = 0; i < FilmDirectors.Count - 1; ++i)
            {
                ret += FilmDirectors[i].Person.Name;
                ret += ", ";
            }
            ret += FilmDirectors[i].Person.Name;
            return ret;
        }

        public string stringActors()
        {
            var ret = "";
            int i;
            for (i = 0; i < FilmActors.Count - 1; ++i)
            {
                ret += FilmActors[i].Person.Name;
                ret += ", ";
            }
            ret += FilmActors[i].Person.Name;
            return ret;
        }

        public string stringGenre()
        {
            if (Genre == FilmGenre.Action)
            {
                return "Экшн";
            }
            else if (Genre == FilmGenre.Comedy)
            {
                return "Комедия";
            }
            else if (Genre == FilmGenre.Documentary)
            {
                return "Документальный фильм";
            }
            else if (Genre == FilmGenre.Drama)
            {
                return "Драма";
            }
            else if (Genre == FilmGenre.Fantasy)
            {
                return "Фэнтези";
            }
            else if (Genre == FilmGenre.Thriller)
            {
                return "Триллер";
            }
            else if (Genre == FilmGenre.Detective)
            {
                return "Детектив";
            }
            else if (Genre == FilmGenre.ScienceFiction)
            {
                return "Научная фантастика";
            }
            else
            {
                return "Прочее";
            }
        }

        // foreign keys
        public List<FilmDirectorJoin> FilmDirectors { get; set; }
        public List<FilmReview> FilmReviews { get; set; }
        public List<FilmActorJoin> FilmActors { get; set; }
    }

}