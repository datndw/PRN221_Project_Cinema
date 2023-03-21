using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PRN221_Project_Cinema.Models;

namespace PRN221_Project_Cinema.Pages
{
    public class IndexModel : PageModel
    {
        private readonly PRN221_Project_CinemaContext _context;

        public IndexModel(PRN221_Project_CinemaContext context)
        {
            _context = context;
        }

        [BindProperty]
        public List<Movie> Movies { get; set; }

        [ViewData]
        public List<Genre> Genres { get; set; }
        
        [FromQuery(Name="id")]
        public string GenreId { get; set; }
        
        [BindProperty(SupportsGet = true)]
        public string film { get; set; }

        public void OnGet()
        {
            Movies = _context.Movies.ToList();
            Genres = _context.Genres.ToList();

            if (!string.IsNullOrEmpty(GenreId))
            {
                Movies = _context.Movies
                    .Where(m => m.GenreId == int.Parse(GenreId))
                    .ToList();
            }
            if (!string.IsNullOrEmpty(film))
            {
                Movies = _context.Movies.Where(m => m.Title.Contains(film))
                    .ToList();
            }
            else
            {
                Movies = _context.Movies.ToList();
            }
        }
        
    }
}