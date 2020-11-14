using DotnetMoviesAppRazor.Data;
using DotnetMoviesAppRazor.Models.ViewModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotnetMoviesAppRazor.Infrastructure.Services
{
    public class UserService
    {
        private readonly DatabaseContext _db;

        public UserService(DatabaseContext db)
        {
            _db = db;
        }

        public async Task<UserViewModel> GetUser(int id)
        {
            var user = await _db.Users
                 .Include(u => u.FavouriteFilms)
                 .FirstOrDefaultAsync(u => u.Id == id);

            return user != null
                ? new UserViewModel(user)
                : null;
        }

        public async Task<List<ReviewViewModel>> GetUserReviews(int userId)
        {
            var reviews = await _db.FilmReviews
                .Include(r => r.Film)
                .Where(r => r.AuthorId == userId)
                .ToListAsync();

            return reviews
                .Select(r => new ReviewViewModel(r, ReviewViewModel.Caller.User))
                .ToList();
        }

        public async Task<List<FilmViewModel>> GetUserFavouriteFilms(int userId)
        {
            var favouriteFilms = await _db.Films
                .Include(f => f.Directors)
                .Include(f => f.Actors)
                .Include(f => f.Reviews)
                .ThenInclude(r => r.Author)
                .Where(f => f.FavouriteOfUsers.Any(u => u.Id == userId))
                .ToListAsync();

            return favouriteFilms
                .Select(f => new FilmViewModel(f))
                .ToList();
        }

        public async Task AddFavouriteFilm(int filmId, int userId)
        {
            var user = await _db.Users
                .Include(u => u.FavouriteFilms)
                .FirstOrDefaultAsync(u => u.Id == userId);

            if (user == null)
            {
                throw new InvalidOperationException("The user has not been found");
            }

            if (user.FavouriteFilms.Any(f => f.Id == filmId))
            {
                throw new InvalidOperationException("The film is already favourited by the user");
            }

            var film = await _db.Films.FindAsync(filmId);
            user.FavouriteFilms.Add(film);

            await _db.SaveChangesAsync();
        }

        public async Task RemoveFilmFromFavourites(int filmId, int userId)
        {
            var user = await _db.Users
                .Include(u => u.FavouriteFilms)
                .FirstOrDefaultAsync(u => u.Id == userId);

            if (user == null)
            {
                throw new InvalidOperationException("The user has not been found");
            }

            if (user.FavouriteFilms.All(f => f.Id != filmId))
            {
                throw new InvalidOperationException("The film is not favourited by the user");
            }

            user.FavouriteFilms.RemoveAll(f => f.Id == filmId);
            await _db.SaveChangesAsync();
        }

        public async Task DeleteReview(int reviewId, int currentUserId)
        {
            var user = await _db.Users
            .Include(u => u.Reviews)
            .FirstOrDefaultAsync(u => u.Id == currentUserId);

            if (user == null)
            {
                throw new InvalidOperationException("The user has not been found");
            }

            if (user.Reviews.All(r => r.Id != reviewId))
            {
                throw new InvalidOperationException($"A review with id {reviewId} has not been found");
            }

            user.Reviews.RemoveAll(r => r.Id == reviewId);
            await _db.SaveChangesAsync();
        }
    }
}
