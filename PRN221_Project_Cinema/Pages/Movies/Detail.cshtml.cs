using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using PRN221_Project_Cinema.Models;

namespace PRN221_Project_Cinema.Pages.Movies
{
    public class DetailModel : PageModel
    {
        private readonly PRN221_Project_CinemaContext _context;
        private readonly IHubContext<CinemaHub> _hub;

        public DetailModel(PRN221_Project_CinemaContext context, IHubContext<CinemaHub> hub)
        {
            _context = context;
            _hub = hub;
        }

        public Movie Movie { get; set; }
        public List<Rate> RateList { get; set; }

        [BindProperty]
        public Rate CurrentRate { get; set; }
        public Rate RawRate { get; set; }

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

            CurrentRate = _context.Rates.Where(r => r.PersonId == 7).Where(r => r.MovieId == MovieId).FirstOrDefault();
            RawRate = CurrentRate;
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                ViewData["msg"] = "Please try again!";
            }
            else
            {
                if (RawRate == null)
                {
                    CurrentRate.MovieId = MovieId;
                    CurrentRate.PersonId = 7;
                    _context.Rates.Add(CurrentRate);
                }
                else
                {
                    var rate = _context.Rates.Where(r => r.PersonId == 7).FirstOrDefault();
                    rate.NumericRating = CurrentRate.NumericRating;
                    rate.Comment = CurrentRate.Comment;
                    _context.Rates.Update(rate);
                }
                await _context.SaveChangesAsync();
                await _hub.Clients.All.SendAsync("ReloadMovie", await _context.Rates.ToListAsync());
            }

            return RedirectToPage("./Detail", new { id = MovieId.ToString() });
        }
    }
}
