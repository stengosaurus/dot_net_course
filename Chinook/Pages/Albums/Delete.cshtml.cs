using Chinook.Data;
using Chinook.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Chinook.Pages.Albums
{
    public class DeleteModel : PageModel
    {
        private readonly ChinookContext _context;

        public DeleteModel(ChinookContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Album Album { get; set; }


        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null) return NotFound();

            Album = await _context.Albums
                .Include(a => a.Artist)
                .FirstOrDefaultAsync(a => a.AlbumId == id);

            if (Album == null) return NotFound();

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null) return NotFound();

            var album = await _context.Albums.FindAsync(id);

            if (album != null)
            {
                _context.Albums.Remove(album);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("/Index");
        }
    }
}
