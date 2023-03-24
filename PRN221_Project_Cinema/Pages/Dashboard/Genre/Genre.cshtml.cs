using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PRN221_Project_Cinema.Models;

namespace PRN221_Project_Cinema.Pages
{
    public class GenreModel : PageModel
    {
        private readonly PRN221_Project_CinemaContext _context;

        public GenreModel(PRN221_Project_CinemaContext context)
        {
            _context = context;
        }

        [BindProperty]
        public List<Genre> Genres { get; set; }

        [BindProperty(SupportsGet = true)]
        public string GenreSearch { get; set; }

        public async Task OnGetAsync()
        {
            if (_context.Genres != null)
            {
                Genres = await _context.Genres.ToListAsync();
            }
            if (!string.IsNullOrEmpty(GenreSearch))
            {
                Genres = Genres.Where(g => g.Description
                    .ToLower()
                    .Contains(GenreSearch.ToLower()))
                    .ToList();
            }
        }
    }
}
