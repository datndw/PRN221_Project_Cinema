using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PRN221_Project_Cinema.Models;
using System.Security.Claims;

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

        [ViewData]
        public int totalMovies { get; set; }

        [FromQuery(Name = "id")]
        public string GenreId { get; set; }

        [BindProperty(SupportsGet = true)]
        public string film { get; set; }

        public List<Rate> RateList { get; set; }

        [BindProperty]
        public int TotalPages { get; set; }

        [FromQuery(Name = "page")]
        public int CurrentPage { get; set; }

        public IActionResult OnGet(int page = 1)
        {

            var identityValue = (ClaimsIdentity)User.Identity;
            IEnumerable<Claim> claims = identityValue.Claims;
            if(claims.Any()) {
                HttpContext.Session.SetString("email", claims.First().Value);
                HttpContext.Session.SetString("fullname", claims.ElementAt(1).Value);
                var role = claims.ElementAt(2).Value;

                if (role == "Admin")
                {
                    return RedirectToPage("/Dashboard/Dashboard");
                }
            }

           
            Movies = _context.Movies.ToList();
            const int pageSize = 6;
           

            totalMovies = _context.Movies.Count();
            // set the page to CurrentPage when user clicks another link
            page = CurrentPage;

            TotalPages = (int)Math.Ceiling(_context.Movies.Count() / 6.0);
            Movies = Movies.Skip((page - 1) * pageSize).Take(pageSize).ToList();

            if (!string.IsNullOrEmpty(film))
            {
                Movies = _context.Movies.Where(m => m.Title.Contains(film)).ToList();
            }
            if (!string.IsNullOrEmpty(GenreId))
            {
                Movies = _context.Movies.Where(m => m.GenreId == int.Parse(GenreId)).ToList();
            }
            Genres = _context.Genres.ToList();
            RateList = _context.Rates.ToList();

            return Page();
        }
       

    }
}