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

    public List<Album> Albums { get; set; } = new();

    public string SearchTerm { get; set; }

    public async Task OnGetAsync(string search)
    {
        var query = _context.Albums.Include(a => a.Artist).AsQueryable();

        if (!string.IsNullOrWhiteSpace(search))
        {
            query = query.Where(a =>
                a.Title.Contains(search) ||
                a.Artist.Name.Contains(search));
        }

        Albums = await query.ToListAsync();
        SearchTerm = search;
    }
}
