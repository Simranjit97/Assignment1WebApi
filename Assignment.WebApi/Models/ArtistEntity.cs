using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment.WebApi.Models
{
    public class ArtistEntity
    {
        public int artistId { get; set; }
        public string name { get; set; }
        public DateTime birthdate { get; set; }
        public string country { get; set; }
        public string city { get; set; }
    }
}
