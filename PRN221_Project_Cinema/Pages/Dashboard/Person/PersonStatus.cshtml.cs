using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PRN221_Project_Cinema.Models;
using System.Data;

namespace PRN221_Project_Cinema.Pages
{

    [Authorize(Roles = "Admin")]
    public class PersonStatusModel : PageModel
    {
        private readonly PRN221_Project_CinemaContext _context;

        public PersonStatusModel(PRN221_Project_CinemaContext context)
        {
            _context = context;
        }

        [BindProperty]
        public bool? IsChanged { get; set; } = false;

        [BindProperty]
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
            IsChanged = Person.IsActive;
            //Person = person;
            return Page();
        }
        public async Task<IActionResult> OnPostAsync()
        {
            /* _context.Attach(Person).State = EntityState.Modified;*/

            var person = await _context.Persons.FirstOrDefaultAsync(x => x.PersonId == Person.PersonId);

            if (person == null)
            {
                return NotFound(nameof(Person));
            }

            person.IsActive = IsChanged;
            Person = person;

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
