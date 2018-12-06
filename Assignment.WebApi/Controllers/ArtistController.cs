using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Assignment.WebApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Assignment.WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/Artist")]
    public class ArtistController : Controller
    {
        MyDbContext myDbContext = new MyDbContext();
        // GET: api/Artist
        [HttpGet("getArtist")]
        public async Task<IActionResult> Get()
        {
            try
            {
                var songs = myDbContext.Artist.Select(s => new
                {
                    artistId = s.ArtistId,
                    name = s.Name,
                    birthdate = s.Birthdate,
                    country = s.Country,
                    city = s.City,
                    
                }).ToList();

                return Ok(songs);
            }
            catch
            {
                return BadRequest();
            }
        }

        // GET: api/Artist/5
        [HttpGet("{id}", Name = "Get")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {

                var songs = myDbContext.Artist.Where(a => a.ArtistId == id).Select(a => new
                {
                    artistId = a.ArtistId,
                    name = a.Name,
                    birthdate = a.Birthdate,
                    country = a.Country,
                    city = a.City,
                }).ToList();

                return Ok(songs);
            }
            catch
            {
                return BadRequest();
            }
        }
        
        // POST: api/Artist
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]ArtistEntity value)
        {
            try
            {
                var artist = new Artist()
                {
                    ArtistId = value.artistId,
                    Name = value.name,
                    Birthdate = value.birthdate,
                    Country = value.country,
                    City = value.city,
                };
                myDbContext.Add(artist);
                myDbContext.SaveChanges();
                return Ok(artist);
            }
            catch
            {
                return BadRequest();
            }
        }
        
        // PUT: api/Artist/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody]ArtistEntity value)
        {
            try
            {

                var artist = myDbContext.Artist.Find(value.artistId);
                artist.Name = value.name;
                artist.Birthdate = value.birthdate;
                artist.Country = value.country;
                artist.City = value.city;

                myDbContext.SaveChanges();
                return Ok(artist);
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
                var artist = myDbContext.Artist.Find(id);
                myDbContext.Artist.Remove(artist);
                myDbContext.SaveChanges();
                return Ok(artist);
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
