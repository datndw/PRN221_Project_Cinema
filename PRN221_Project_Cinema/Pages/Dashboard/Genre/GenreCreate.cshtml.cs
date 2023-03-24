using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.SignalR;
using PRN221_Project_Cinema.Models;
using System.Data;

namespace PRN221_Project_Cinema.Pages
{

    [Authorize(Roles = "Admin")]
    public class GenreCreateModel : PageModel
    {
        private readonly PRN221_Project_CinemaContext _context;
        private readonly IHubContext<CinemaHub> _hubContext;
        
        [BindProperty]
        public List<Genre> Genres { get; set; }
        public GenreCreateModel(PRN221_Project_CinemaContext context, IHubContext<CinemaHub> hubContext)
        {
            _context = context;
            _hubContext = hubContext;
        }
       
        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Genre Genre { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid || _context.Genres == null || Genre == null)
            {
                return Page();
            }

            _context.Genres.Add(Genre);
            await _context.SaveChangesAsync();
            await _hubContext.Clients.All.SendAsync("ReloadMovie");

            return RedirectToPage("./Genre");
        }
    }
}
