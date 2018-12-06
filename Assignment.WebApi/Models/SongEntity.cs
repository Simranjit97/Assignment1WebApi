using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment.WebApi.Models
{
    public class SongEntity
    {
        public int songId { get; set; }
        public string name { get; set; }
        public TimeSpan length { get; set; }
        public decimal? bitrate { get; set; }
        public decimal? size { get; set; }
        public string genere { get; set; }
        public int artist { get; set; }
        public int? year { get; set; }
    }
}
