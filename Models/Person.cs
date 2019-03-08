using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace MoviesApp.Models
{
    public class Person
    {        
        public int PersonId { get; set; }
        
        [Required]
        [MaxLength(128)]
        public string Name { get; set; }
    }
}