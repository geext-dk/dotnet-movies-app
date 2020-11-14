using System.ComponentModel.DataAnnotations;

namespace DotnetMoviesAppRazor.Models.Input
{
    public class CreateReviewModel
    {
        [Required]
        public int FilmId { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Body { get; set; }
    }
}
