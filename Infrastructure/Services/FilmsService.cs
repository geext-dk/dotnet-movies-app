using DotnetMoviesAppRazor.Data;
using DotnetMoviesAppRazor.Models.ViewModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotnetMoviesAppRazor.Infrastructure.Services
{
    public class FilmsService
    {
        public enum SearchCriteria
        {
            Title = 0,
            Director,
            Actor,
            Year,
            Genre
        }

        private readonly DatabaseContext _db;

        public FilmsService(DatabaseContext db)
        {
            _db = db;
        }

        public async Task<FilmViewModel> GetFilm(int id)
        {
            var film = await _db.Films
                .Include(f => f.Actors)
                .Include(f => f.Directors)
                .Include(f => f.Reviews)
                    .ThenInclude(r => r.Author)
                .FirstOrDefaultAsync(f => f.Id == id);

            return new FilmViewModel(film);
        }

        public async Task<IEnumerable<FilmViewModel>> GetFilms(SearchCriteria criterion, string searchString, int sortOption)
        {
            if (searchString == null)
            {
                searchString = "";
            }
            Comparer<Film> cmp;
            if (sortOption == 0)
            {
                // Alphabet sort
                cmp = Comparer<Film>.Create((f1, f2) => f1.Title.ToLower().CompareTo(f2.Title.ToLower()));
            }
            else
            {
                cmp = Comparer<Film>.Create((f1, f2) => f1.ReleaseYear - f2.ReleaseYear);
            }

            IQueryable<Film> query = _db.Films
                .Include(f => f.Actors)
                .Include(f => f.Directors)
                .Include(f => f.FavouriteOfUsers)
                .Include(f => f.Reviews)
                .ThenInclude(r => r.Author);

            if (!string.IsNullOrEmpty(searchString))
            {
                switch (criterion)
                {
                    case SearchCriteria.Title:
                        {
                            query = query.Where(f => f.Title.ToLower().Contains(searchString.ToLower()));
                            break;
                        }
                    case SearchCriteria.Actor:
                        {
                            query = query
                                .Where(f => f.Actors
                                    .Any(fa => fa.Name.ToLower().Contains(searchString.ToLower())));
                            break;
                        }
                    case SearchCriteria.Director:
                        {
                            query = query
                                .Where(f => f.Directors
                                    .Any(fd => fd.Name.ToLower().Contains(searchString.ToLower())));
                            break;
                        }
                    case SearchCriteria.Year:
                        {
                            var year = 0;
                            if (int.TryParse(searchString, out year))
                            {
                                query = query.Where(f => f.ReleaseYear == year);
                            }
                            break;
                        }
                    case SearchCriteria.Genre:
                        {
                            var genres = Enum.GetValues<FilmGenre>().Select(g => new
                            {
                                Id = g,
                                Name = FilmViewModel.GenreToString(g).ToLower()
                            })
                                .Where(o => o.Name.Contains(searchString.ToLower()))
                                .Select(o => o.Id)
                                .ToList();

                            query = query.Where(f => genres.Contains(f.Genre));
                            break;

                        }
                }
            }

            if (sortOption == 1)
            {
                query = query.OrderByDescending(f => f.ReleaseYear);
            }
            else if (sortOption == 2)
            {
                query = query.OrderBy(f => f.ReleaseYear);
            }
            else
            {
                query = query.OrderBy(f => f.Title);
            }

            var results = await query.ToListAsync();

            return results.Select(r => new FilmViewModel(r)).ToList();
        }

        public async Task CreateReview(string title, string body, int filmId, int userId)
        {
            var film = await _db.Films
                .Include(f => f.Reviews)
                .FirstOrDefaultAsync(f => f.Id == filmId);

            if (film == null)
            {
                throw new InvalidOperationException("The film has not been found");
            }

            film.Reviews.Add(new Review
            {
                Body = body,
                Title = title,
                AuthorId = userId
            });

            await _db.SaveChangesAsync();
        }
    }
}
