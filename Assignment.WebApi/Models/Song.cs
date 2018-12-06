using System;
using System.Collections.Generic;

namespace Assignment.WebApi.Models
{
    public partial class Song
    {
        public int SongId { get; set; }
        public string Name { get; set; }
        public TimeSpan Length { get; set; }
        public decimal? Bitrate { get; set; }
        public decimal? Size { get; set; }
        public string Genere { get; set; }
        public int Artist { get; set; }
        public int? Year { get; set; }

        public virtual Artist ArtistNavigation { get; set; }
    }
}
