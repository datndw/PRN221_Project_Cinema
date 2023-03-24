using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PRN221_Project_Cinema.Models;

namespace PRN221_Project_Cinema.Pages
{
    public class PersonStatusModel : PageModel
    {
        private readonly PRN221_Project_CinemaContext _context;

        public PersonStatusModel(PRN221_Project_CinemaContext context)
        {
            _context = context;
        }

        [BindProperty]
        public bool? isChanged { get; set; } = false;

        public Person Person { get; set; } 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Persons == null)
            {
                return NotFound();
            }

            Person = await _context.Persons.FirstOrDefaultAsync(m => m.PersonId == id);
            if (Person == null)
            {
                return NotFound();
            }
            isChanged = Person.IsActive;
            //Person = person;
            return Page();
        }
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            /* _context.Attach(Person).State = EntityState.Modified;*/

            Person.IsActive = isChanged;

            try
            {
                _context.Persons.Update(Person);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PersonExists(Person.PersonId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Person");
        }

        private bool PersonExists(int id)
        {
            return (_context.Persons?.Any(e => e.PersonId == id)).GetValueOrDefault();
        }
    }
}
