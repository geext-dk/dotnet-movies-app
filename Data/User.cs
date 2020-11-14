using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace DotnetMoviesAppRazor.Data
{
    public class User : IdentityUser<int>
    {
        public List<Review> Reviews { get; set; } = new();
        public List<Film> FavouriteFilms { get; set; } = new();
    }
}