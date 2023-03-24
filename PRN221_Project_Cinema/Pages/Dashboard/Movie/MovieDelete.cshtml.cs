using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using PRN221_Project_Cinema.Models;

namespace PRN221_Project_Cinema.Pages
{
    public class MovieDeleteModel : PageModel
    {
        private readonly PRN221_Project_CinemaContext _context;
        private readonly IHubContext<CinemaHub> _hubContext;
        
        [BindProperty]
        public Movie Movie { get; set; }
        public MovieDeleteModel(PRN221_Project_CinemaContext context, IHubContext<CinemaHub> hubContext)
        {
            _context = context;
            _hubContext = hubContext;
        }
        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Movies == null)
            {
                return NotFound();
            }

            var movie = await _context.Movies.FirstOrDefaultAsync(m => m.MovieId == id);

            if (movie == null)
            {
                return NotFound();
            }
            else
            {
                Movie = movie;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Movies == null)
            {
                return NotFound();
            }
            var movie = await _context.Movies.FindAsync(id);

            if (movie != null)
            {
                Movie = movie;
                _context.Movies.Remove(Movie);
                await _context.SaveChangesAsync();
                await _hubContext.Clients.All.SendAsync("ReloadMovie");
            }

            return RedirectToPage("./Movie");
        }
    }
}
