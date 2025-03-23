using System.ComponentModel.DataAnnotations.Schema;

namespace Chinook.Models
{
    [Table("tracks")]
    public class Track
    {
        [Column("trackid")]
        public int TrackId { get; set; }

        [Column("name")]
        public string Name { get; set; } = string.Empty;

        [Column("albumid")]
        public int AlbumId { get; set; }

        [Column("composer")]
        public string Composer { get; set; }

        [Column("mediatypeid")]
        public int MediaTypeId { get; set; }

        [Column("milliseconds")]
        public int Milliseconds { get; set; }

        [Column("bytes")]
        public int? Bytes { get; set; }

        [Column("unitprice")]
        public decimal UnitPrice { get; set; }

        // Navigation
        public Album Album { get; set; }

    }
}
