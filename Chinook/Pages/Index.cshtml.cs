using Chinook.Data;
using Chinook.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Chinook.Pages;

public class IndexModel : PageModel
{
    private readonly ChinookContext _context;

    public IndexModel(ChinookContext context)
    {
        _context = context;
    }

    // ✅ Add this:
    public List<Album> Albums { get; set; } = new();

    public async Task OnGetAsync()
    {
        Albums = await _context.Albums
            .Include(a => a.Artist)
            .ToListAsync();
    }
}
