using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PRN221_Project_Cinema.Models;
using System.Data;

namespace PRN221_Project_Cinema.Pages
{
    [Authorize(Roles = "Admin")]
    public class PersonCreateModel : PageModel
    {
        private readonly PRN221_Project_CinemaContext _context;

        public PersonCreateModel(PRN221_Project_CinemaContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Person Person { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid || _context.Persons == null || Person == null)
            {
                return Page();
            }

            _context.Persons.Add(Person);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Person");
        }
    }
}
