using DotnetMoviesAppRazor.Data;
using DotnetMoviesAppRazor.Infrastructure.Services;
using DotnetMoviesAppRazor.Models.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DotnetMoviesAppRazor.Pages.User
{
    [Authorize]
    public class ProfileModel : PageModel
    {
        private readonly AuthenticationService _authenticationService;
        private readonly UserService _userService;

        public ProfileModel(AuthenticationService authenticationService, UserService userService)
        {
            _authenticationService = authenticationService;
            _userService = userService;
        }

        public UserViewModel CurrentUser { get; set; }
        public List<FilmViewModel> FavouriteFilms { get; set; } = new();
        public List<ReviewViewModel> Reviews { get; set; } = new();

        public async Task<ActionResult> OnGetAsync(int? userId)
        {
            if (userId == null)
            {
                CurrentUser = await _authenticationService.GetCurrentUserAsync();
                if (CurrentUser == null)
                {
                    return Unauthorized();
                }
            }
            else
            {
                CurrentUser = await _userService.GetUser(userId.Value);
                if (CurrentUser == null)
                {
                    return NotFound();
                }
            }

            Reviews = await _userService.GetUserReviews(CurrentUser.Id);
            FavouriteFilms = await _userService.GetUserFavouriteFilms(CurrentUser.Id);

            return Page();
        }

        public async Task<ActionResult> OnPostDeleteReviewAsync(int reviewId)
        {
            var currentUser = await _authenticationService.GetCurrentUserAsync();
            if (currentUser == null)
                return Unauthorized();

            await _userService.DeleteReview(reviewId, currentUser.Id);
            return RedirectToPage();
        }
    }
}
