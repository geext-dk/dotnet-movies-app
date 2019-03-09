using System;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using MoviesApp.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using System.Collections.Generic;
using System.Collections.Immutable;
using MoviesApp.ViewModels;

namespace MoviesApp.Controllers
{
    [Authorize]
    public class UserController : Controller
    {
        private DatabaseContext db;

        public UserController(DatabaseContext dbContext) {
            db = dbContext;
        }

        [HttpPost]
        public IActionResult FavoritesAdd(int filmId)
        {
            Console.WriteLine("Favorites Add Film: " + filmId);
            User currentUser = db.Users
                .Include(u => u.Favorites)
                .FirstOrDefault(u => u.Email == User.Identity.Name);
            if (currentUser == null)
            {
                return Unauthorized();
            }
            foreach (Favorite favorite in currentUser.Favorites)
            {
                Console.WriteLine($"Favorite: FilmId: {favorite.FilmId}, UserId: {favorite.UserId}");
            }
            Favorite fav = currentUser.Favorites.FirstOrDefault(f => f.FilmId == filmId);
            if (fav == null)
            {
                Console.WriteLine("Favorite is null");
                currentUser.Favorites.Add(new Favorite {
                    UserId = currentUser.Id,
                    FilmId = filmId
                });
                db.SaveChanges();
            }
            return RedirectToAction("Info", "Home", new { id = filmId });
        }


        [HttpPost]
        public IActionResult FavoritesRemove(int filmId)
        {
            Console.WriteLine("======== Removing ========");
            User currentUser = db.Users
                .Include(u => u.Favorites)
                .FirstOrDefault(u => u.Email == User.Identity.Name);
            if (currentUser == null)
            {
                return Unauthorized();
            }
            currentUser.Favorites.RemoveAll(f => f.FilmId == filmId);
            db.SaveChanges();
            
            return RedirectToAction("Info", "Home", new { id = filmId });
        }

        public IActionResult Profile()
        {
            User currentUser = db.Users
                .Include(u => u.Favorites)
                    .ThenInclude(fav => fav.Film)
                .Include(u => u.FilmReviews)
                    .ThenInclude(fr => fr.Film)
                .FirstOrDefault(u => u.UserName == User.Identity.Name);
            if (currentUser == null)
            {
                return Unauthorized();
            }

            return View(currentUser);
        }

        [HttpPost]
        public IActionResult ReviewsAdd(AddReviewModel model)
        {
            User currentUser = db.Users.First(u => u.UserName == User.Identity.Name);
            if (ModelState.IsValid)
            {
                var fr = new FilmReview
                {
                    Body = model.Body,
                    Title = model.Title,
                    FilmId = model.FilmId,
                    UserId = currentUser.Id
                };
                db.FilmReviews.Add(fr);
                db.SaveChanges();
            }
            return RedirectToAction("Info", "Home", new { id = model.FilmId });
        }

        [HttpPost]
        public IActionResult ReviewsRemove(int filmReviewId)
        {
            User currentUser = db.Users.First(u => u.UserName == User.Identity.Name);
            db.FilmReviews.Remove(db.FilmReviews.Single(fr => fr.FilmReviewId == filmReviewId));
            db.SaveChanges();
            return RedirectToAction("Profile", "User");
        }
    }
}