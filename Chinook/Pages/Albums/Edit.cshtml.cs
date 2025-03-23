using Chinook.Data;
using Chinook.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Chinook.Pages.Albums
{
    public class EditModel : PageModel
    {
        private readonly ChinookContext _context;

        public EditModel(ChinookContext context)
        {
            _context = context;
        }

        [BindProperty]
        public string ArtistName { get; set; } = "";

        [BindProperty]
        public Album Album { get; set; } = new Album();

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null) return NotFound();

            Album = await _context.Albums
                .Include(a => a.Artist)
                .FirstOrDefaultAsync(a => a.AlbumId == id);

            if (Album == null) return NotFound();

            ArtistName = Album.Artist != null ? Album.Artist.Name : "";

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid) return Page();

            if (string.IsNullOrWhiteSpace(ArtistName))
            {
                ModelState.AddModelError("ArtistName", "Artist name is required.");
                return Page();
            }

            var albumToUpdate = await _context.Albums.FindAsync(Album.AlbumId);
            if (albumToUpdate == null) return NotFound();

            var artist = await _context.Artists
                .FirstOrDefaultAsync(a => a.Name.ToLower() == ArtistName.ToLower());

            if (artist == null)
            {
                artist = new Artist { Name = ArtistName };
                _context.Artists.Add(artist);
                await _context.SaveChangesAsync();
            }

            albumToUpdate.Title = Album.Title;
            albumToUpdate.ArtistId = artist.ArtistId;

            await _context.SaveChangesAsync();

            return RedirectToPage("/Index");
        }
    }
}
