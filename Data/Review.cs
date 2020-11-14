using System;
using System.ComponentModel.DataAnnotations;

namespace DotnetMoviesAppRazor.Data
{
    public class Review
    {
        public int Id { get; set; }
        
        [Required]
        [MaxLength(2048)]
        public string Title { get; set; }

        public string Body { get; set; }

        public int FilmId { get; set; }
        public Film Film { get; set; }

        public int AuthorId { get; set; }
        public User Author { get; set; }

    }
}