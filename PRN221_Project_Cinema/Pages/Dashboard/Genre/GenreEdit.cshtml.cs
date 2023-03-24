using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using PRN221_Project_Cinema.Models;

namespace PRN221_Project_Cinema.Pages
{
    public class GenreEditModel : PageModel
    {
        private readonly PRN221_Project_CinemaContext _context;
        private readonly IHubContext<CinemaHub> _hubContext;

        public GenreEditModel(PRN221_Project_CinemaContext context, IHubContext<CinemaHub> hubContext)
        {
            _context = context;
            _hubContext = hubContext;
        }

        [BindProperty]
        public Genre Genre { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Genres == null)
            {
                return NotFound();
            }

            var genre = await _context.Genres.FirstOrDefaultAsync(m => m.GenreId == id);
            if (genre == null)
            {
                return NotFound();
            }
            Genre = genre;
            return Page();
        }
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Genre).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
                await _hubContext.Clients.All.SendAsync("ReloadMovie");
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GenreExists(Genre.GenreId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Genre");
        }

        private bool GenreExists(int id)
        {
            return (_context.Genres?.Any(e => e.GenreId == id)).GetValueOrDefault();
        }
    }
}
