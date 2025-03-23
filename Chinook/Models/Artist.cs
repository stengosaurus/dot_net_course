using System.ComponentModel.DataAnnotations.Schema;

namespace Chinook.Models
{
    [Table("artists")]
    public class Artist
    {
        [Column("artistid")]
        public int ArtistId { get; set; }

        [Column("name")]
        public string Name { get; set; } = string.Empty;

        // Navigation property
        public List<Album> Albums { get; set; } = new();
    }
}
