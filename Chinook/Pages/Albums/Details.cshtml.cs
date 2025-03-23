using Chinook.Data;
using Chinook.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Chinook.Pages.Albums
{
    public class DetailsModel : PageModel
    {
        private readonly ChinookContext _context;

        public DetailsModel(ChinookContext context)
        {
            _context = context;
        }

        public Album Album { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            Album = await _context.Albums
                .Include(a => a.Artist)
                .Include(a => a.Tracks)
                .FirstOrDefaultAsync(a => a.AlbumId == id);

            if (Album == null)
            {
                return NotFound();
            }

            return Page();
        }
    }
}
