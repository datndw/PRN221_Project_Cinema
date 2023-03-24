using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PRN221_Project_Cinema.Models;
using PRN221_Project_Cinema.SendMailModels;
using System;
using System.Net.Mail;

namespace PRN221_Project_Cinema.Pages.Account
{
    public class ForgotPasswordModel : PageModel
    {
        private readonly PRN221_Project_CinemaContext _context;

        public ForgotPasswordModel(PRN221_Project_CinemaContext context)
        {
            _context= context;
        }
        public void OnGet()
        {
        }

        [BindProperty]
        public Email sendmail { get; set; }

        public async Task OnPost()
        {
            string To = sendmail.To;

            var person = _context.Persons.FirstOrDefault(x => x.Email == To);

            if (person == null)
            {
                ViewData["wrongEmail"] = "Email này không dùng để đăng ký tài khoản";
                return;
            }

            person.Password = RandomString(5);

            string Subject = "Xin chào";
            string Body = "mật khẩu mới của bạn là: " + person.Password;
            MailMessage mm = new MailMessage();
            mm.To.Add(To);
            mm.Subject = Subject;
            mm.Body = Body;
            mm.IsBodyHtml = false;
            mm.From = new MailAddress("hoangtth.work@gmail.com");
            SmtpClient smtp = new SmtpClient("smtp.gmail.com");
            smtp.Port = 587;
            smtp.UseDefaultCredentials = false;
            smtp.EnableSsl = true;
            smtp.Credentials = new System.Net.NetworkCredential("hoangtth.work@gmail.com", "uzoqtxwwgwiqkqgq");
            await smtp.SendMailAsync(mm);
            ViewData["Message"] = "Một thông báo đã gửi đến " + sendmail.To;
            _context.Persons.Update(person);
            _context.SaveChanges();
        }

        private static Random random = new Random();

        public static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }

   
}
