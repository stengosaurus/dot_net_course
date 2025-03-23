using Microsoft.EntityFrameworkCore;
using Chinook.Models;

namespace Chinook.Data
{
    public class ChinookContext : DbContext
    {
        public ChinookContext(DbContextOptions<ChinookContext> options)
            : base(options) { }

        public DbSet<Album> Albums => Set<Album>();
        public DbSet<Artist> Artists => Set<Artist>();
        public DbSet<Track> Tracks => Set<Track>();
    }
}
