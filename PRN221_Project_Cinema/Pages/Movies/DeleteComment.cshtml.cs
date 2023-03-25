using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using PRN221_Project_Cinema.Models;

namespace PRN221_Project_Cinema.Pages.Movies
{
    public class DeleteCommentModel : PageModel
    {
        private readonly PRN221_Project_CinemaContext _context;
        private readonly IHubContext<CinemaHub> _hubContext;

        [BindProperty]
        public Genre Genre { get; set; }
        public DeleteCommentModel(PRN221_Project_CinemaContext context, IHubContext<CinemaHub> hubContext)
        {
            _context = context;
            _hubContext = hubContext;
        }
        public async Task<IActionResult> OnPostDeleteCommentAsync(int id)
        {
            var comment = await _context.Rates.FindAsync(id);

            if (comment == null)
            {
                return NotFound();
            }
            else
            {
                _context.Rates.Remove(comment);
                await _context.SaveChangesAsync();
                await _hubContext.Clients.All.SendAsync("ReloadMovie");
            }
            return RedirectToPage("/Movies/Details", new { id = comment.MovieId });
        }
    }
}
