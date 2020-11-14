using DotnetMoviesAppRazor.Data;
using System.Collections.Generic;
using System.Linq;

namespace DotnetMoviesAppRazor.Models.ViewModel
{
    public class UserViewModel
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public List<int> FavouriteFilmIds { get; set; } = new();

        public UserViewModel(User user)
        {
            Id = user.Id;
            Email = user.Email;
            FavouriteFilmIds = user.FavouriteFilms.Select(ff => ff.Id).ToList();
        }
    }
}
