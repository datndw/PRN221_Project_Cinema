using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PRN221_Project_Cinema.Models;

namespace PRN221_Project_Cinema.Pages
{
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

        public async Task OnGetAsync()
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
        }
    }
}
