using DotnetMoviesAppRazor.Data;
using DotnetMoviesAppRazor.Models.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotnetMoviesAppRazor.Infrastructure.Services
{
    public class AuthenticationService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly DatabaseContext _db;

        public AuthenticationService(IHttpContextAccessor httpContextAccessor, DatabaseContext db)
        {
            _httpContextAccessor = httpContextAccessor;
            _db = db;
        }

        public async Task<UserViewModel> GetCurrentUserAsync()
        {
            var httpContext = _httpContextAccessor.HttpContext;
            var user = await _db.Users
                 .Include(u => u.FavouriteFilms)
                 .FirstOrDefaultAsync(u => u.UserName == httpContext.User.Identity.Name);

            return user != null
                ? new UserViewModel(user)
                : null;
        }
    }
}
