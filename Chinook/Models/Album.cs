using System.ComponentModel.DataAnnotations.Schema;

namespace Chinook.Models
{
    [Table("albums")] // for Album.cs
    public class Album
    {
        [Column("albumid")]
        public int AlbumId { get; set; }

        [Column("title")]
        public string Title { get; set; } = string.Empty;

        [Column("artistid")]
        public int ArtistId { get; set; }

        public Artist Artist { get; set; }

        public List<Track> Tracks { get; set; } = new();
    }
}
