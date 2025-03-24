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

        [BindProperty]
        public List<string> TrackNames { get; set; } = new();

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null) return NotFound();

            Album = await _context.Albums
                .Include(a => a.Artist)
                .Include(a => a.Tracks)
                .FirstOrDefaultAsync(a => a.AlbumId == id);

            if (Album == null) return NotFound();

            ArtistName = Album.Artist?.Name ?? "";
            TrackNames = Album.Tracks.Select(t => t.Name).ToList();

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

            if (TrackNames == null || TrackNames.Count == 0)
            {
                ModelState.AddModelError(string.Empty, "At least one track is required.");
                return Page();
            }

            var albumToUpdate = await _context.Albums
                .Include(a => a.Tracks)
                .FirstOrDefaultAsync(a => a.AlbumId == Album.AlbumId);

            if (albumToUpdate == null) return NotFound();

            // Find or create artist
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

            // Clear existing tracks and add new ones
            _context.Tracks.RemoveRange(albumToUpdate.Tracks);

            foreach (var name in TrackNames)
            {
                if (!string.IsNullOrWhiteSpace(name))
                {
                    var track = new Track
                    {
                        Name = name,
                        AlbumId = albumToUpdate.AlbumId,
                        MediaTypeId = 1,
                        Milliseconds = 180000,
                        UnitPrice = 0.99m
                    };
                    _context.Tracks.Add(track);
                }
            }

            await _context.SaveChangesAsync();
            return RedirectToPage("/Index");
        }
    }
}
