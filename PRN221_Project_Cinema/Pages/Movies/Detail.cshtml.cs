using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PRN221_Project_Cinema.Models;

namespace PRN221_Project_Cinema.Pages.Movies
{
    public class DetailModel : PageModel
    {
        private readonly PRN221_Project_CinemaContext _context;

        public DetailModel(PRN221_Project_CinemaContext context)
        {
            _context = context;
        }

        public Movie Movie { get; set; }
        public List<Rate> RateList { get; set; }

        public IActionResult OnGet(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Movie = _context.Movies.Where(m => m.MovieId == id)
                .Include(m => m.Genre)
                .FirstOrDefault();

            RateList = _context.Rates.Where(r => r.MovieId == id)
                .Include(r => r.Person)
                .ToList();

            return Page();
        }
    }
}
