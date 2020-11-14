using DotnetMoviesAppRazor.Data;

namespace DotnetMoviesAppRazor.Models.ViewModel
{
    public class ReviewViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public UserViewModel Author { get; set; }
        public FilmViewModel Film { get; set; }

        public enum Caller
        {
            User,
            Film
        }

        public ReviewViewModel(Review review, Caller caller)
        {
            Id = review.Id;
            Title = review.Title;
            Body = review.Body;
            if (caller == Caller.Film)
            {
                Author = new UserViewModel(review.Author);
            }
            else
            {
                Film = new FilmViewModel(review.Film);
            }
        }
    }
}
