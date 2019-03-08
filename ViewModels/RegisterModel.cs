using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace MoviesApp.ViewModels
{
    public class RegisterModel
    {
        
        [Required(ErrorMessage="Email is required")]
        public string Email { get; set; }

        [Required(ErrorMessage="Password is required")]
        [DataType(DataType.Password)]
        public string Password { get; set; }


        [Compare("Password", ErrorMessage="Passwords don't match")]
        [DataType(DataType.Password)]
        public string PasswordConfirm { get; set; }
    }
}