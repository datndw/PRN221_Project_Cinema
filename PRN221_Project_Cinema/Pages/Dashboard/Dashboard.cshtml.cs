using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PRN221_Project_Cinema.Models;
using PRN221_Project_Cinema.Extensions;
using Microsoft.AspNetCore.Authorization;

namespace PRN221_Project_Cinema.Pages
{
    [Authorize(Roles = "Admin")] 
    
    public class DashboardModel : PageModel
    {
        private readonly PRN221_Project_CinemaContext _context;
        [BindProperty]
        public Dictionary<string,int> GenresInfo { get; set; }
        [BindProperty]
        public Dictionary<string, double> MovieRate { get; set; }
        [BindProperty]
        public Dictionary<string, int> PersonActiveData { get; set; }
        [BindProperty]
        public int MovieCount { get; set; }
        [BindProperty]
        public int GenreCount { get; set; }
        [BindProperty]
        public int PersonCount { get; set; }
        [BindProperty]
        public int ActivePersonCount { get; set; }
        private int MovieCountLastYear { get; set; }
        [BindProperty]
        public double Change { get; set; }


        public DashboardModel(PRN221_Project_CinemaContext context)
        {
            _context = context;
        }

        public async Task OnGetAsync()
        {
            if (_context.Movies != null)
            {
                GenresInfo = await _context.Movies
                    .Include(m => m.Genre)
                    .GroupBy(m => m.Genre.Description)
                    .Select(g => new
                    {
                        genre = g.Key,
                        quantity = g.Count()
                    })
                    .OrderByDescending(m => m.quantity)
                    .ToDictionaryAsync(el => el.genre, el => el.quantity);
            }
            if(_context.Rates != null)
            {
                MovieRate = await _context.Rates
                    .Include(r => r.Movie)
                    .GroupBy(r => r.Movie.Title)
                    .Select(mr => new
                    {
                        movie = mr.Key,
                        rating = mr
                        .Average(r => r.NumericRating) ?? -1
                    })
                    .Take(3)
                    .OrderByDescending(m => m.rating)
                    .ToDictionaryAsync(el => el.movie.StringShortener(15), el => el.rating);
            }
            if (_context.Movies != null 
                && _context.Genres != null
                && _context.Persons != null)
            {
                MovieCount = _context.Movies
                    .Count();
                MovieCountLastYear = _context.Movies
                    .Where(m => m.Year <= DateTime.Now.Year -1)
                    .Count();
                GenreCount = _context.Genres
                    .Count();
                PersonCount = _context.Persons
                    .Count();
                ActivePersonCount = _context.Persons
                    .Where(p => p.IsActive == true)
                    .Count();
            }
            Change = Math.Round((double)(MovieCount / MovieCountLastYear - 1) * 100, 1);
            if(_context.Rates != null)
            {
                PersonActiveData = await _context.Rates
                    .Include(r => r.Person)
                    .GroupBy(r => r.Person.Fullname ?? "Name not specified!")
                    .Select(p => new
                    {
                        person = p.Key,
                        quantity = p.Count()
                    })
                    .Take(5)
                    .OrderByDescending(m => m.quantity)
                    .ToDictionaryAsync(el => el.person.StringShortener(15), el => el.quantity);

            }
        }
    }
}
