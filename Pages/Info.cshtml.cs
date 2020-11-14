using DotnetMoviesAppRazor.Models.Input;
using DotnetMoviesAppRazor.Models.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using DotnetMoviesAppRazor.Data;
using System.Linq;
using System.Threading.Tasks;
using DotnetMoviesAppRazor.Infrastructure.Services;
using Microsoft.AspNetCore.Authorization;
using System;
using Microsoft.Extensions.Logging;
using System.Text.Json;

namespace DotnetMoviesAppRazor.Pages
{
    public class InfoModel : PageModel
    {
        private readonly AuthenticationService _authenticationService;
        private readonly FilmsService _filmsService;
        private readonly UserService _userService;
        private readonly ILogger<InfoModel> _logger;

        public InfoModel(AuthenticationService authenticationService, FilmsService filmsService,
            UserService userService, ILogger<InfoModel> logger)
        {
            _authenticationService = authenticationService;
            _filmsService = filmsService;
            _userService = userService;
            _logger = logger;
        }

        public FilmViewModel Film { get; set; }
        public UserViewModel CurrentUser { get; set; }

        public async Task OnGetAsync(int id)
        {
            CurrentUser = await _authenticationService.GetCurrentUserAsync();
            Film = await _filmsService.GetFilm(id);
        }

        public async Task<ActionResult> OnPostAddFavouriteAsync(int filmId)
        {
            var currentUser = await _authenticationService.GetCurrentUserAsync();
            if (currentUser == null)
                return Unauthorized();

            await _userService.AddFavouriteFilm(filmId, currentUser.Id);

            return RedirectToPage(new
            {
                id = filmId
            });
        }

        public async Task<ActionResult> OnPostRemoveFavouriteAsync(int filmId)
        {
            var currentUser = await _authenticationService.GetCurrentUserAsync();
            if (currentUser == null)
                return Unauthorized();

            await _userService.RemoveFilmFromFavourites(filmId, currentUser.Id);

            return RedirectToPage(new
            {
                id = filmId
            });
        }

        public async Task<ActionResult> OnPostCreateReviewAsync(CreateReviewModel model)
        {
            var user = await _authenticationService.GetCurrentUserAsync();
            if (user == null)
                return Unauthorized();

            if (ModelState.IsValid)
            {
                await _filmsService.CreateReview(model.Title, model.Body, model.FilmId, user.Id);
            }

            return RedirectToPage(new
            {
                id = model.FilmId
            });
        }
    }
}
