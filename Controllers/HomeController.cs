using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using MoviesApp.Models;
using MoviesApp.ViewModels;

namespace MoviesApp.Controllers
{
    public enum SearchCriteria
    {
        Title,
        Director,
        Actor,
        Year,
        Genre,
        N_VARS
    }

    public class HomeController : Controller
    {
        private DatabaseContext db;
        public HomeController(DatabaseContext dbContext)
        {
            db = dbContext;
        }

        public IActionResult Index()
        {
            return View(db.Films
                .Include(f => f.FilmDirectors)
                    .ThenInclude(fd => fd.Person)
                .Include(f => f.FilmActors)
                    .ThenInclude(fa => fa.Person)
                .ToList());
        }

        public IActionResult Info(int id)
        {
            var film = db.Films
                .Include(f => f.FilmDirectors)
                    .ThenInclude(fd => fd.Person)
                .Include(f => f.FilmActors)
                    .ThenInclude(fa => fa.Person)
                .Include(f => f.FilmReviews)
                    .ThenInclude(fr => fr.User)
                .FirstOrDefault(f => f.FilmId == id);
            var user = db.Users.SingleOrDefault(u => u.UserName == User.Identity.Name);
            if (user != null)
            {
                db.Entry(user).Collection(u => u.Favorites).Load();
            }
            if (film == null)
            {
                return NotFound();
            }

            return View(new AddReviewModel { FilmId = id });
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult PartialGet(int criterion, string searchString, int sortOption)
        {
            if (searchString == null)
            {
                searchString = "";
            }
            Comparer<Film> cmp;
            if (sortOption == 0)
            {
                // Alphabet sort
                cmp = Comparer<Film>.Create((f1, f2) => f1.Title.CompareTo(f2.Title));
            }
            else
            {
                cmp = Comparer<Film>.Create((f1, f2) => f1.ReleaseYear - f2.ReleaseYear);
            }
            var ret = new List<Film>();
            HttpContext.Response.ContentType = "application/json";
            if (criterion >= (int)SearchCriteria.N_VARS) {
                return PartialView(ret);
            }
            SearchCriteria searchCriterion = (SearchCriteria) criterion;

            if (!string.IsNullOrEmpty(searchString))
            {
                db.Films
                    .Include(f => f.FilmActors)
                        .ThenInclude(fa => fa.Person)
                    .Include(f => f.FilmDirectors)
                        .ThenInclude(fd => fd.Person);
                switch (searchCriterion)
                {
                    case SearchCriteria.Title: {
                        ret.AddRange(db.Films.Where(f => f.Title.Contains(searchString)));
                        break;
                    }
                    case SearchCriteria.Actor: {
                        ret.AddRange(db.Films.Where(f => f.FilmActors.Any(fa => fa.Person.Name.Contains(searchString))));
                        break;
                    }
                    case SearchCriteria.Director: {
                        ret.AddRange(db.Films.Where(f => f.FilmDirectors.Any(fd => fd.Person.Name.Contains(searchString))));
                        break;
                    }
                    case SearchCriteria.Year: {
                        int year = 0;
                        if (int.TryParse(searchString, out year)) {
                            ret.AddRange(db.Films.Where(f => f.ReleaseYear == year));
                        }
                        break;
                    }
                    case SearchCriteria.Genre: {
                        ret.AddRange(db.Films.Where(f => f.stringGenre().Contains(searchString)));
                        break;

                    }
                }
            }
            else
            {
                ret.AddRange(db.Films.ToList());
            }
            
            if (sortOption == 1)
            {
                return PartialView(ret.OrderByDescending(f => f.ReleaseYear));
            }
            else if (sortOption == 2)
            {
                return PartialView(ret.OrderBy(f => f.ReleaseYear));
            }

            return PartialView(ret.OrderBy(f => f.Title));
            
        }

    }
}
