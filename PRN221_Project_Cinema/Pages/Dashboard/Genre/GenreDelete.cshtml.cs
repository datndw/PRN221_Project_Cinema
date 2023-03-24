using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using PRN221_Project_Cinema.Models;
using System.Data;

namespace PRN221_Project_Cinema.Pages
{
    [Authorize(Roles = "Admin")]
    public class GenreDeleteModel : PageModel
    {
        private readonly PRN221_Project_CinemaContext _context;
        private readonly IHubContext<CinemaHub> _hubContext;
        
        [BindProperty]
        public Genre Genre { get; set; }
        public GenreDeleteModel(PRN221_Project_CinemaContext context, IHubContext<CinemaHub> hubContext)
        {
            _context = context;
            _hubContext = hubContext;
        }

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
            else
            {
                Genre = genre;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Genres == null)
            {
                return NotFound();
            }
            var genre = await _context.Genres.FindAsync(id);

            if (genre != null)
            {
                Genre = genre;
                _context.Genres.Remove(Genre);
                await _context.SaveChangesAsync();
                await _hubContext.Clients.All.SendAsync("ReloadMovie");
            }

            return RedirectToPage("./Genre");
        }
    }
}
