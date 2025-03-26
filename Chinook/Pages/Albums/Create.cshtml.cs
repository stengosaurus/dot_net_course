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


        // this is the constructor where we inject the ChinookContext
        public CreateModel(ChinookContext context)
        {
            _context = context;
        }

        // these are the properties that will be bound to the form fields
        // the BindProperty attribute is used to bind the form fields to the properties
        // the properties are initialized with default values
        // the properties are public so they can be accessed from the Razor Page
        [BindProperty]
        // the Title property is bound to the form field with the same name
        public string Title { get; set; } = "";

        [BindProperty]
        // the ArtistName property is bound to the form field with the same name
        public string ArtistName { get; set; } = "";

        // this property will be used to store the list of artists
        public List<Artist> Artists { get; set; } = new();

        // this method is called when the page is requested. It returns the page
        public async Task<IActionResult> OnGetAsync()
        {
            Artists = await _context.Artists.ToListAsync();
            return Page();
        }

        // this method is called when the form is submitted and the page is posted back
        public async Task<IActionResult> OnPostAsync()
        {   
            // check if the Title and ArtistName properties are empty. If they are, add a model error
            if (string.IsNullOrWhiteSpace(Title) || string.IsNullOrWhiteSpace(ArtistName)){
                // add a model error
                ModelState.AddModelError(string.Empty, "Title and Artist are required.");
                // get the list of artists
                Artists = await _context.Artists.ToListAsync();
                // return the page
                return Page();
            }

            // check if the artist already exists in the database. If it does, get the artist. If it doesn't, create a new artist
            var artist = await _context.Artists
                .FirstOrDefaultAsync(a => a.Name.ToLower() == ArtistName.ToLower());

            // if the artist does not exist, create a new artist
            if (artist == null){
                // create a new artist
                artist = new Artist { Name = ArtistName };
                // add the artist to the context
                _context.Artists.Add(artist);
                // save the changes
                await _context.SaveChangesAsync();
            }

            // create a new album
            var newAlbum = new Album{
                // set the properties of the new album
                Title = Title,
                // set the ArtistId property of the new album to the ArtistId of the artist
                ArtistId = artist.ArtistId
            };

            // add the new album to the context
            _context.Albums.Add(newAlbum);
            // save the changes
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