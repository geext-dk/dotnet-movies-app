using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace DotnetMoviesAppRazor.Pages.Account
{
    public class RegisterModel : PageModel
    {
        private readonly UserManager<Data.User> _userManager;
        private readonly SignInManager<Data.User> _signInManager;

        public RegisterModel(UserManager<Data.User> userManager, SignInManager<Data.User> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [Required(ErrorMessage = "Email is required")]
        [BindProperty]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        [BindProperty]
        public string Password { get; set; }

        [Compare("Password", ErrorMessage = "Passwords don't match")]
        [DataType(DataType.Password)]
        [BindProperty]
        public string PasswordConfirm { get; set; }

        public void OnGet()
        {
        }

        public async Task<ActionResult> OnPostAsync()
        {
            if (ModelState.IsValid)
            {
                var user = new Data.User
                {
                    Email = Email,
                    UserName = Email
                };

                var result = await _userManager.CreateAsync(user, Password);
                if (result.Succeeded)
                {
                    await _signInManager.SignInAsync(user, false);
                    return RedirectToPage("/Index");
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                }
            }

            return Page();
        }
    }
}
