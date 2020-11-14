using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace DotnetMoviesAppRazor.Data
{
    public class Person
    {        
        public int PersonId { get; set; }
        
        [Required]
        [MaxLength(128)]
        public string Name { get; set; }

        public List<Film> DirectoredFilms { get; set; } = new();
        public List<Film> ActoredFilms { get; set; } = new();
    }
}