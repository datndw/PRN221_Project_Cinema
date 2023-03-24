using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.SignalR;
using PRN221_Project_Cinema.Models;

namespace PRN221_Project_Cinema.Pages
{
    public class MovieCreateModel : PageModel
    {
        private readonly PRN221_Project_CinemaContext _context;
        private readonly IHubContext<CinemaHub> _hubContext;
        
        [BindProperty]
        public Movie Movie { get; set; }
        public MovieCreateModel(PRN221_Project_CinemaContext context, IHubContext<CinemaHub> hubContext)
        {
            _context = context;
            _hubContext = hubContext;
        }
       
        public IActionResult OnGet()
        {
            ViewData["GenreId"] = new SelectList(_context.Genres, "GenreId", "GenreId");
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid || _context.Movies == null || Movie == null)
            {
                return Page();
            }

            _context.Movies.Add(Movie);
            await _context.SaveChangesAsync();
            await _hubContext.Clients.All.SendAsync("ReloadMovie");

            return RedirectToPage("./Movie");
        }
    }
}
