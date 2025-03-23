using Chinook.Data;
using Chinook.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Chinook.Pages.Albums
{
    public class CreateModel : PageModel
    {
        private readonly ChinookContext _context;

        public CreateModel(ChinookContext context)
        {
            _context = context;
        }

        [BindProperty]
        public string Title { get; set; } = "";

        [BindProperty]
        public string ArtistName { get; set; } = "";

        public List<Artist> Artists { get; set; } = new();

        public async Task<IActionResult> OnGetAsync()
        {
            Artists = await _context.Artists.ToListAsync();
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (string.IsNullOrWhiteSpace(Title) || string.IsNullOrWhiteSpace(ArtistName)){
                ModelState.AddModelError(string.Empty, "Title and Artist are required.");
                Artists = await _context.Artists.ToListAsync();
                return Page();
            }

            var artist = await _context.Artists
                .FirstOrDefaultAsync(a => a.Name.ToLower() == ArtistName.ToLower());

            if (artist == null){
                artist = new Artist { Name = ArtistName };
                _context.Artists.Add(artist);
                await _context.SaveChangesAsync();
            }

            var newAlbum = new Album{
                Title = Title,
                ArtistId = artist.ArtistId
            };

            _context.Albums.Add(newAlbum);
            await _context.SaveChangesAsync(); // Save now to get AlbumId

            // Handle Track input
            var trackNames = Request.Form["TrackNames"];
            foreach (var trackName in trackNames){
                if (!string.IsNullOrWhiteSpace(trackName)){
                    var track = new Track{
                        Name = trackName,
                        AlbumId = newAlbum.AlbumId,
                        MediaTypeId = 1, // default dummy value
                        Milliseconds = 180000, // default dummy value
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
