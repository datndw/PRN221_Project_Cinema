using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PRN221_Project_Cinema.Models;
using System.Security.Claims;
using System.Security.Principal;

namespace PRN221_Project_Cinema.Pages.Account
{
    public class LoginModel : PageModel
    {
        private readonly PRN221_Project_CinemaContext _context;
        public LoginModel(PRN221_Project_CinemaContext _context)
        {
            this._context = _context;
        }

        [BindProperty]
        public Person person { get; set; }
        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost(Person? person)
        {
            if (ModelState.IsValid)
            {
                Person p = _context.Persons.Where(x => x.Email == person.Email && x.Password == person.Password).FirstOrDefault();
                if (p != null)
                {
                    var scheme = CookieAuthenticationDefaults.AuthenticationScheme;

                    var identity = new ClaimsIdentity(new[] { new Claim(ClaimTypes.Email, p.Email), new Claim(ClaimTypes.Name, p.Fullname), new Claim(ClaimTypes.Role, p.Type == 1 ? "Admin" : "Member") }
                    , scheme);
                    var user = new ClaimsPrincipal(identity);
                    
                    await HttpContext.SignInAsync(scheme, user, new AuthenticationProperties
                    {
                        IsPersistent = true,
                        ExpiresUtc = DateTime.UtcNow.AddDays(1),
                        AllowRefresh = true
                    });

                    HttpContext.Session.SetString("email", p.Email);
                    HttpContext.Session.SetString("fullname", p.Fullname);
                    
                    return RedirectToPage("../Index");
                }
                else
                {
                    ViewData["wrongaccount"] = "Email đăng nhập hoặc mật khẩu không đúng";
                    return Page();
                }
            }
            else
            {
                return Page();
            }
        }

        public async Task<IActionResult> OnPostLogoutAsync()
        {
            //var identity = (ClaimsIdentity)User.Identity;
            //IEnumerable<Claim> claims = identity.Claims;

            var scheme = CookieAuthenticationDefaults.AuthenticationScheme;
            HttpContext.Session.Remove("email");
            await HttpContext.SignOutAsync(scheme);
            return RedirectToPage("../Index");
        }
    }
}
