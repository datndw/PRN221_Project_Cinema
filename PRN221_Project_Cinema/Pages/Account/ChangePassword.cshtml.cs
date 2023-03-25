using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PRN221_Project_Cinema.Models;

namespace PRN221_Project_Cinema.Pages.Account
{
    [Authorize(Roles = "Member")]
    public class ChangePasswordModel : PageModel
    {
        private readonly PRN221_Project_CinemaContext _context;
        public ChangePasswordModel(PRN221_Project_CinemaContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> OnGetAsync()
        {
            return Page();
        }
        public async Task<IActionResult> OnPostAsync(string? curPass, string? newPass, string? renewPass)
        {
            Person p;
            bool isInvalid = false;
            var email = HttpContext.Session.GetString("email");
            p = _context.Persons.FirstOrDefault(p => p.Email == email);
            if (curPass != null)
            {
                if (p != null)
                {
                    if (newPass != renewPass)
                    {
                        isInvalid = true;
                        ViewData["notMatch"] = "Mật khẩu mới không khớp";

                    }
                    if (curPass == newPass && newPass == renewPass)
                    {
                        isInvalid = true;
                        ViewData["notMatch"] = "??? khac gi nhau";
                    }
                    if (p.Password != curPass)
                    {
                        isInvalid = true;
                        ViewData["wrongPassword"] = "Mật khẩu cũ không chính xác";
                        //return Page();
                    }
                    
                    if (isInvalid)
                    {
                        return Page();
                    }
                }
            }
            p.Password = newPass;
            _context.Persons.Update(p);
            await _context.SaveChangesAsync();
            ViewData["success"] = "Đổi mật khẩu thành công!";
            return Page();
        }
    }
}
