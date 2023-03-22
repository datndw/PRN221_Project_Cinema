using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PRN221_Project_Cinema.Models;

namespace PRN221_Project_Cinema.Pages.Movies
{
    public class DetailModel : PageModel
    {
        private readonly PRN221_Project_CinemaContext _context;

        public DetailModel(PRN221_Project_CinemaContext context)
        {
            _context = context;
        }

        public Movie Movie { get; set; }
        public List<Rate> RateList { get; set; }

        [BindProperty]
        public Rate NewRate { get; set; }

        [FromQuery(Name = "id")]
        public int MovieId { get; set; }

        public IActionResult OnGet()
        {
            if (MovieId == null)
            {
                return NotFound();
            }

            Movie = _context.Movies.Where(m => m.MovieId == MovieId)
                .Include(m => m.Genre)
                .FirstOrDefault();

            RateList = _context.Rates.Where(r => r.MovieId == MovieId)
                .Include(r => r.Person)
                .ToList();

            return Page();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                ViewData["msg"] = "Please try again!";
            }
            else
            {
                NewRate.MovieId = 315162;
                NewRate.PersonId = 7;
                _context.Add(NewRate);
                _context.SaveChanges();
            }

            return RedirectToPage("./Detail", new { id = MovieId.ToString() });
        }
    }
}
