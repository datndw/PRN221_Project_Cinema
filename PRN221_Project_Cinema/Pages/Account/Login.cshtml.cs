using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PRN221_Project_Cinema.Models;

namespace PRN221_Project_Cinema.Pages.Account
{
    public class LoginModel : PageModel
    {
        private readonly PRN221_Project_CinemaContext _context;
        public LoginModel(PRN221_Project_CinemaContext _context)
        {
            this._context = _context;
        }

        [BindProperty]
        public Person person { get; set; }
        public void OnGet()
        {
        }
    }
}
