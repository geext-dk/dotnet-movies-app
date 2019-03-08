using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace MoviesApp.ViewModels
{
    public class LoginModel
    {
        [Required(ErrorMessage="Email is required")]
        public string Email { get; set; }

        [Required(ErrorMessage="Password is required")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public bool RememberMe { get; set; }
    }
}