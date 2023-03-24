using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PRN221_Project_Cinema.Models;
using System.Data;

namespace PRN221_Project_Cinema.Pages
{

    [Authorize(Roles = "Admin")]
    public class MovieModel : PageModel
    {
        private readonly PRN221_Project_CinemaContext _context;

        public MovieModel(PRN221_Project_CinemaContext context)
        {
            _context = context;
        }

        [BindProperty]
        public List<Movie> Movies { get; set; }

        [BindProperty(SupportsGet = true)]
        public string MovieSearch { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            if (_context.Movies != null)
            {
                Movies = await _context.Movies
                .Include(m => m.Genre).ToListAsync();
            }
            if (!string.IsNullOrEmpty(MovieSearch))
            {
                Movies = Movies.Where(m => m.Title
                    .ToLower()
                    .Contains(MovieSearch.ToLower()))
                    .ToList();
            }

            return Page();
        }
    }
}
