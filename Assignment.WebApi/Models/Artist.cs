using System;
using System.Collections.Generic;

namespace Assignment.WebApi.Models
{
    public partial class Artist
    {
        public Artist()
        {
            Song = new HashSet<Song>();
        }

        public int ArtistId { get; set; }
        public string Name { get; set; }
        public DateTime Birthdate { get; set; }
        public string Country { get; set; }
        public string City { get; set; }

        public virtual ICollection<Song> Song { get; set; }
    }
}
