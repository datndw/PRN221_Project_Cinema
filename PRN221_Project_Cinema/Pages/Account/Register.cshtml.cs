using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PRN221_Project_Cinema.Models;

namespace PRN221_Project_Cinema.Pages.Account
{
    public class RegisterModel : PageModel
    {
        private readonly PRN221_Project_CinemaContext _context;

        public RegisterModel(PRN221_Project_CinemaContext _context)
        {
            this._context = _context;
        }

        [BindProperty]
        public Person person { get; set; }
        public void OnGet()
        {
            //var gender = Request.Form["gender"];
        }

        public async Task<IActionResult> OnPost(Person? person)
        {
            if (ModelState.IsValid)
            {
                var p = await _context.Persons.FirstOrDefaultAsync(x => x.Email == person.Email);
                if (p == null)
                {
                    var gender = Request.Form["gender"];
                    person.Gender = gender;
                    person.Type = 2;
                    person.IsActive = true;
                    await _context.Persons.AddAsync(person);
                    await _context.SaveChangesAsync();
                    return RedirectToPage("./Login");
                }
                else
                {
                    ViewData["emailExist"] = "Email này đã tồn tại, Vui lòng lựa chọn email khác";
                    return Page();
                }

            }

            return Page();

        }
    }
}
