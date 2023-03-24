using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PRN221_Project_Cinema.Models;

namespace PRN221_Project_Cinema.Pages
{
    [Authorize(Roles = "Admin")]
    public class DashboardPersonModel : PageModel
    {
        private readonly PRN221_Project_CinemaContext _context;

        public DashboardPersonModel(PRN221_Project_CinemaContext context)
        {
            _context = context;
        }

        [BindProperty]
        public List<Person> Persons { get; set; }

        [BindProperty(SupportsGet = true)]
        public string PersonSearch { get; set; }
        public async Task OnGetAsync()
        {
            if (_context.Persons != null)
            {
                Persons = await _context.Persons.ToListAsync();
            }
            if (!string.IsNullOrEmpty(PersonSearch))
            {
                Persons = Persons.Where(p => p.Fullname
                    .ToLower()
                    .Contains(PersonSearch.ToLower()))
                    .ToList();
            }
        }
    }
}
