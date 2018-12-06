using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Assignment.WebApi.Models;

namespace Assignment.WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/Songs")]
    public class SongController : Controller
    {
        MyDbContext myDbContext = new MyDbContext();
        // GET: api/Songs
        [HttpGet("getSongs")]
        public async Task<IActionResult> Get()
        {
            try
            {
                var songs = myDbContext.Song.Select(s => new
                {
                    songId = s.SongId,
                    name = s.Name,
                    length = s.Length,
                    bitRate = s.Bitrate,
                    size = s.Size,
                    genere = s.Genere,
                    artist = s.Artist,
                    year = s.Year
                }).ToList();

                return Ok(songs);
            }
            catch
            {
                return BadRequest();
            }
        }

        // GET: api/Songs/5
        [HttpGet("{id}", Name = "findSong")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {

                var songs = myDbContext.Song.Where(s => s.SongId == id).Select(s => new
                {
                    songId = s.SongId,
                    name = s.Name,
                    length = s.Length,
                    bitRate = s.Bitrate,
                    size = s.Size,
                    genere = s.Genere,
                    artist = s.Artist,
                    year = s.Year
                }).ToList();

                return Ok(songs);
            }
            catch
            {
                return BadRequest();
            }
        }

        // POST: api/Songs
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]SongEntity value)
        {

            try
            {
                var song = new Song()
                {
                    SongId = value.songId,
                    Name = value.name,
                    Length = value.length,
                    Bitrate = value.bitrate,
                    Size = value.size,
                    Genere = value.genere,
                    Artist = value.artist,
                    Year = value.year
                };
                myDbContext.Add(song);
                myDbContext.SaveChanges();
                return Ok(song);
            }
            catch
            {
                return BadRequest();
            }
        }

        // PUT: api/Songs/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody]SongEntity value)
        {
            try
            {

                var song = myDbContext.Song.Find(value.songId);
                song.Name = value.name;
                song.Length = value.length;
                song.Bitrate = value.bitrate;
                song.Size = value.size;
                song.Genere = value.genere;
                song.Artist = value.artist;
                song.Year = value.year;

                myDbContext.SaveChanges();
                return Ok(song);
            }
            catch
            {
                return BadRequest();
            }
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var song = myDbContext.Song.Find(id);
                myDbContext.Song.Remove(song);
                myDbContext.SaveChanges();
                return Ok(song);
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
