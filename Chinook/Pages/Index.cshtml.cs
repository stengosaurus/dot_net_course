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

    public string SearchTerm { get; set; } = "";
    public string CurrentSort { get; set; } = "asc";

    public async Task OnGetAsync(string search, string sortOrder)
    {
        var query = _context.Albums.Include(a => a.Artist).AsQueryable();

        if (!string.IsNullOrWhiteSpace(search))
        {
            query = query.Where(a =>
                a.Title.Contains(search) ||
                a.Artist.Name.Contains(search));
        }

        // Determine current sort direction
        CurrentSort = string.IsNullOrWhiteSpace(sortOrder) ? "asc" : sortOrder.ToLower();

        query = CurrentSort switch
        {
            "desc" => query.OrderByDescending(a => a.Title),
            _ => query.OrderBy(a => a.Title),
        };

        Albums = await query.ToListAsync();
        SearchTerm = search;
    }
}
